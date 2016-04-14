using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using UsedCar.ViewModels;
using Common.Utils;
using Service.Abstract;

namespace UsedCar.WebBack.Controllers
{
    public class BaseController : Controller
    {
        public const string SuperAdminUserName = "BlueSky";
        public const string SuperAdminUserPWD = "lifelight";

        #region 对象引用

        //[Ninject.Inject]
        //internal ICarService m_ICarService { get; set; }

        [Ninject.Inject]
        internal IDicService m_IDicService { get; set; }
        #endregion

        #region 账号权限

        /// <summary>
        /// 设置登陆的用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected void SetCurrentUser(SysUser user, string reminduser)
        {
            //Session赋值
            Session[WEBUtility.UserSessionName()] = user;
            //如果选中记住我，则记录cookie信息
            HttpCookie userCookie = new HttpCookie(WEBUtility.UserSessionName());
            if (reminduser == "1")
            {
                userCookie.Values["UserAccounts"] = HttpUtility.UrlEncode(user.LoginName, System.Text.Encoding.UTF8);
                //userCookie.Domain = AdminUserCookieDomain;
                userCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(userCookie);
            }
            else
            {
                userCookie.Values["UserAccounts"] = null;
                // userCookie.Domain = AdminUserCookieDomain;
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }
        }
        /// <summary>
        /// 获取当前用户，先从session中获取，如果登录时选择了记住我，则判断cookie是否存在，并自动登录。
        /// </summary>
        protected SysUser GetCurrentUser()
        {
            SysUser resultUser = null;
            resultUser = Session[WEBUtility.UserSessionName()] as SysUser;

            if (resultUser != null && resultUser.Id > 0)
            {
                return resultUser;
            }
            //else if (Request.Cookies[WEBUtility.UserSessionName()] != null)
            //{
            //    HttpCookie userCookie = Request.Cookies[WEBUtility.UserSessionName()];
            //    string UserAccounts = userCookie.Values["UserAccounts"];
            //    //string UserPassword = userCookie.Values["UserPassword"];

            //    if (!string.IsNullOrWhiteSpace(UserAccounts))
            //    {
            //        var model = new SysUser();
            //        model.LoginName = HttpUtility.UrlDecode(UserAccounts, System.Text.Encoding.UTF8);
            //        //model.LoginPwd = HttpUtility.UrlDecode(UserPassword, System.Text.Encoding.UTF8);

            //        resultUser = model;
            //    }
            //}
            return resultUser;
        }
        /// <summary>
        /// 从Cookies中获取用户名
        /// </summary>
        /// <returns></returns>
        protected string GetUserAccounts()
        {
            string UserAccounts = "";
            if (Request.Cookies[WEBUtility.UserSessionName()] != null)
            {
                HttpCookie userCookie = Request.Cookies[WEBUtility.UserSessionName()];
                UserAccounts = HttpUtility.UrlDecode(userCookie.Values["UserAccounts"], System.Text.Encoding.UTF8);
            }
            return UserAccounts;
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        protected void logOutUser()
        {
            Session[WEBUtility.UserSessionName()] = null;
            HttpCookie userCookie = new HttpCookie(WEBUtility.UserSessionName());

            userCookie.Values["UserAccounts"] = null;
            // userCookie.Domain = AdminUserCookieDomain;
            userCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userCookie);
        }
        /// <summary>
        /// 判断当前用户是否拥有指定动作的权限
        /// </summary>
        /// <param name="ActionName">动作名称</param>
        /// <returns></returns>
        protected bool HasAction(string ActionName)
        {
            if (ViewBag.HasActions == null)
                return false;
            var HasActions = (IList<SysAction>)ViewBag.HasActions;
            return HasActions.FirstOrDefault(m => m.Name.Equals(ActionName)) != null;
        }
        protected bool HasAction(IList<SysAction> HasActions, string ActionName)
        {
            if (HasActions == null)
                return false;
            //var HasActions = (IList<Actions>)ViewBag.HasActions;
            return HasActions.FirstOrDefault(m => m.Name.Equals(ActionName)) != null;
        }
        /// <summary>
        /// 判断是否具有基础权限
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        protected bool HasAction(IList<SysAction> Model)
        {
            bool f = (HasAction(Model, "查询【车主管理】")
                    || HasAction(Model, "查询【车辆管理】")
                    || HasAction(Model, "查询【故障检测】")
                    || HasAction(Model, "查询【推广信息管理】")
                    || HasAction(Model, "查询【用户管理】")
                    || HasAction(Model, "查询【系统权限管理】")
                    || HasAction(Model, "【系统管理】")
                    || HasAction(Model, "【字典管理】")) ? true : false;
            return f;
        }

        #endregion

        #region 导出EXCEL

        /// <summary>
        /// 导出到Excel(.xls)
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <param name="fileName">文件名（.xls）</param>
        /// <returns></returns>
        protected ActionResult ExportToExcel(DataTable dt, string fileName)
        {
            fileName = Server.MapPath(string.Format("/UpImgs/Temp/{0}", fileName));
            //ExcelRender.RenderToExcelByFileStream(dt, fileName);
            if (System.IO.File.Exists(fileName))
            {
                var name = Path.GetFileName(fileName);
                if (Request.Browser.Browser == "IE")
                    name = HttpUtility.UrlEncode(name);
                return File(fileName, "application/vnd.ms-excel", name);
            }
            else
            {
                return Content("无法生成Excel!");
            }
            /*
            MemoryStream filestream = new MemoryStream(); //内存文件流(应该可以写成普通的文件流)
            filestream = ExcelRender.RenderToExcel(dt);
            filestream.Seek(0, SeekOrigin.Begin);
            if (Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            //return new FileContentResult(filestream.GetBuffer(), "application/vnd.ms-excel");
            return File(filestream, "application/vnd.ms-excel", fileName);
            */
        }
        /// <summary>
        /// 下载EXCEL
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        protected ActionResult DownloadExcel(string fileName)
        {
            string filePath = Server.MapPath(fileName);
            if (Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(Path.GetFileName(fileName));
            return File(filePath, "application/vnd.ms-excel", fileName);
        }

        #endregion

        #region 设置SelectListItem视图包

        /// <summary>
        /// 获取字典项的SelectListItem
        /// </summary>
        /// <param name="DicType">字典类型</param>
        internal void getDicSelectList(string DicType)
        {
            var lst = m_IDicService.getDicNameList(DicType);
            List<SelectListItem> SLItems = new List<SelectListItem>();
            foreach (var item in lst)
            {
                if (string.IsNullOrWhiteSpace(item.KeyValue))
                {
                    continue;
                }
                SLItems.Add(new SelectListItem { Text = item.Name, Value = item.KeyValue });
            }
            ViewBag.DicSelectList = SLItems;
        }

        #endregion

        #region 显示关联字典

        /// <summary>
        /// 获取字典信息中的显示关联字典
        /// </summary>
        internal void getDicDisplayList(string DicType)
        {
            var lst = m_IDicService.getDicNameList(DicType);
            var dicItem = new Dictionary<string, string>();
            foreach (var item in lst)
            {
                if (string.IsNullOrWhiteSpace(item.KeyValue))
                {
                    continue;
                }
                dicItem.Add(item.KeyValue, item.Name);
            }
            ViewBag.DicDisplayList = dicItem;
        }
        #endregion
    }
}
