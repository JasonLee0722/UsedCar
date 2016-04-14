using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

#region Version Info
/* ========================================================================
*   本类功能概述
* 
*   作者：WDF          时间：2014/11/10 13:12:56
*   文件名：NoCacheAttribute
*   版本：V1.0.0
*
*   修改者：           时间：              
*   修改说明：
* ========================================================================
*/
#endregion

namespace UsedCar.WebBack
{
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            //HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoStore();

            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1)); //将 Expires HTTP标头设置为绝对日期和时间。
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false); //指定ASP.NET缓存是否应忽略客户端发送的使缓存无效的 HTTP Cache-Control 标头。
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches); //基于指定的枚举值将 Cache-Control HTTP 标头设置为 must-revalidate 或 proxy-revalidate指令。
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);//将 Cache-Control 标头设置为指定的 System.Web.HttpCacheability 值。
            filterContext.HttpContext.Response.Cache.SetNoStore();//设置 Cache-Control: no-store HTTP 标头。

            base.OnResultExecuting(filterContext);
        }
    }
}