using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsedCar.ViewModels;

namespace System.Web.Mvc
{
    public static class Helpers
    {
        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="stringToSub">原字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="endstring">截取之后尾部跟随的字符窜如：“...”</param>
        /// <returns></returns>
        public static string GetSubString(this HtmlHelper html, string stringToSub, int length, string endstring)
        {
            string str = "";
            if (stringToSub == null)
            {
                return str;
            }
            else
            {
                if (stringToSub.Length > length)
                {
                    str = stringToSub.Substring(0, length) + endstring;
                }
                else
                {
                    str = stringToSub;
                }
                return str;
            }
        }
        #endregion

        #region 给Html.ActionLink加上支持图片链接的功能

        /// <summary>
        /// 给Html.ActionLink加上支持图片链接的功能
        /// </summary>
        /// <param name="html"></param>
        /// <param name="imgSrc"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            //string url = urlHelper.Action(actionName);
            string url = urlHelper.Action(actionName) + "?t=" + DateTime.Now.Ticks;

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName, string controllerName, object routeValue = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string url = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region 查询是否拥有指定动作名称的权限

        /// <summary>
        /// 查询是否拥有指定动作名称的权限
        /// </summary>
        /// <param name="html"></param>
        /// <param name="HasActions"></param>
        /// <param name="ActionName">权限动作名称（例：查询【考试设置】）</param>
        /// <returns></returns>
        public static bool HasAction(this HtmlHelper html, IList<SysAction> HasActions, string ActionName)
        {
            if (HasActions == null)
                return false;
            //var HasActions = (IList<SysAction>)ViewBag.HasActions;
            return HasActions.FirstOrDefault(m => m.Name.Equals(ActionName)) != null;
        }
        /// <summary>
        /// 查询是否拥有指定动作名称的权限
        /// </summary>
        /// <param name="html"></param>
        /// <param name="ActionName">权限动作名称（例：查询【考试设置】）</param>
        /// <returns></returns>
        public static bool HasAction(this HtmlHelper html, string ActionName)
        {
            var HasActions = (IList<SysAction>)html.ViewBag.HasActions;
            if (HasActions == null)
                return false;
            //var HasActions = (IList<SysAction>)ViewBag.HasActions;
            return HasActions.FirstOrDefault(m => m.Name.Equals(ActionName)) != null;
        }

        #endregion

        #region 显示字段关联信息
        public static string DisplayForLinkContent(this HtmlHelper html, string ValueKey, IDictionary<string, string> dicViewBag)
        {
            return dicViewBag.FirstOrDefault(m => m.Key == ValueKey).Value;
        }
        #endregion

    }
}


