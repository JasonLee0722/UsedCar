using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using UsedCar.WebAPIs.Providers;

namespace UsedCar.WebAPIs
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions m_oauthOptions { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            m_oauthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                //AuthorizeEndpointPath = new PathString("/api/user/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                AllowInsecureHttp = true
            };
            // 应用程序适用不记名令牌验证用户身份
            app.UseOAuthBearerTokens(m_oauthOptions);
        }
    }
}