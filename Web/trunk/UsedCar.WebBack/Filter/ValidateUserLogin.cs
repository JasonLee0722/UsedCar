using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsedCar.ViewModels;


namespace UsedCar.WebBack
{
    public class ValidateUserLogin : ActionFilterAttribute
    {
        public ValidateUserLogin() { }
        /// <summary>
        /// 重写系统动作执行前的执行方法 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //从Session中获取登录用户的实体 
            SysUser _SysUser = GetUserInfo(filterContext.RequestContext);
            //string _Controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            //string _Action = filterContext.RouteData.Values["action"].ToString().ToLower();
            if (_SysUser == null || _SysUser.LoginName == null)
            {
                //if (_Controller == "home")
                {
                    filterContext.Result = new RedirectResult("~/Login/Index");
                }
                //else
                //{
                //    filterContext.Result = new RedirectResult("~/SysLogin/IntermediatePage");
                //}
                filterContext.Controller.ViewBag.HasActions = new List<SysAction>();
            }
            else
            {
                filterContext.Controller.ViewBag.HasActions = _SysUser.HasActions;
                filterContext.Controller.ViewBag.UserName = _SysUser.Name;
            }
        }

        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="_RequestContext"></param>
        /// <returns></returns>
        private SysUser GetUserInfo(System.Web.Routing.RequestContext _RequestContext)
        {
            SysUser user = _RequestContext.HttpContext.Session[WEBUtility.UserSessionName()] as SysUser;
            return user;
        }

    }
}