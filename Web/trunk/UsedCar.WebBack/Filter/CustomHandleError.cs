using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsedCar.WebBack
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomHandleErrorAttribute : FilterAttribute, IExceptionFilter //HandleErrorAttribute
    {
        /* public override void OnException(ExceptionContext filterContext)
         {
             SaveExceptionAndError(filterContext);
             base.OnException(filterContext);
         }*/
        public void OnException(ExceptionContext filterContext)
        {
            HttpException _httpException = filterContext.Exception as HttpException;
            if (filterContext.ExceptionHandled == true)
            {
                if (_httpException.GetHttpCode() != 500)//为什么要特别强调500 因为MVC处理HttpException的时候，如果为500 则会自动将其ExceptionHandled设置为true，那么我们就无法捕获异常
                {
                    return;
                }
            }
            if (_httpException != null)
            {
                filterContext.Controller.ViewBag.UrlRefer = filterContext.HttpContext.Request.UrlReferrer;
                if (_httpException.GetHttpCode() == 404)
                {
                    filterContext.HttpContext.Response.Redirect("~/CustomError/NotFound");
                }
                else if (_httpException.GetHttpCode() == 500)
                {
                    filterContext.HttpContext.Response.Redirect("~/CustomError/InternalError");
                }
            }
            
            SaveExceptionAndError(filterContext);//写入日志 记录
            filterContext.ExceptionHandled = true;//设置异常已经处理
        }
        private void SaveExceptionAndError(ExceptionContext exceptionContext)
        {
            string errortime = string.Empty;
            string erroraddr = string.Empty;
            string errorinfo = string.Empty;
            string errorsource = string.Empty;
            string errortrace = string.Empty;
            errortime = "发生时间: " + System.DateTime.Now.ToString();
            erroraddr = "异常位置: " + exceptionContext.RequestContext.HttpContext.Request.Url.ToString();
            var ErrMsg = Logger.GetExceptionDetails(exceptionContext.Exception, new List<string> { exceptionContext.Exception.Message }, "\r\n");
            errorinfo = "异常信息: " + ErrMsg;
            errorsource = "错误源:" + exceptionContext.Exception.Source;
            errortrace = "堆栈信息:" + exceptionContext.Exception.StackTrace;
            //独占方式，因为文件只能由一个进程写入.
            System.IO.StreamWriter writer = null;
            try
            {
                lock (this)
                {
                    // 写入日志
                    string year = DateTime.Now.Year.ToString();
                    string month = DateTime.Now.Month.ToString();
                    string path = string.Empty;
                    string filename = DateTime.Now.Day.ToString() + ".log";
                    path = exceptionContext.RequestContext.HttpContext.Server.MapPath("~/ErrorLogs/") + year + "/" + month;
                    //如果目录不存在则创建
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    System.IO.FileInfo file = new System.IO.FileInfo(path + "/" + filename);

                    writer = new System.IO.StreamWriter(file.FullName, true);//文件不存在就创建,true表示追加
                    writer.WriteLine("用户IP:" + exceptionContext.RequestContext.HttpContext.Request.UserHostAddress);
                    writer.WriteLine(errortime);
                    writer.WriteLine(erroraddr);
                    writer.WriteLine(errorinfo);
                    writer.WriteLine(errorsource);
                    writer.WriteLine(errortrace);
                    writer.WriteLine("--------------------------------------------------------------------------------------");
                    //writer.Close();
                }
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }

}