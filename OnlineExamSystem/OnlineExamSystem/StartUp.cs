using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using OnlineExamSystem.Repository;

[assembly:OwinStartup(typeof(OnlineExamSystem.StartUp))]
namespace OnlineExamSystem
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //enable cors for owin
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigurationOAuth(app);
            //configure oauth on start
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }
        private void ConfigurationOAuth(IAppBuilder app)
        {
            //specifying the type and configuration of token
            //abc.com/token - POST
           // app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions oAuthAuthorization = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleOAuthProvider()
            };
            //token generation logic
            app.UseOAuthAuthorizationServer(oAuthAuthorization);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}