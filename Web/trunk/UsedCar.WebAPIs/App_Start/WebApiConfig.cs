using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace UsedCar.WebAPIs
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // 将 Web API 配置为仅适用不记名令牌身份验证
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationAttribute(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 设置: JSON
            var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings = new JsonSerializerSettings()
            {
                // 设置忽略值为 null 的属性
                NullValueHandling = NullValueHandling.Ignore
            };
            //json.SerializerSettings.Formatting = Formatting.None;

            // 启用跨域
            config.EnableCors();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
