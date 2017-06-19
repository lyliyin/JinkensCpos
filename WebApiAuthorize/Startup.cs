using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;

[assembly: OwinStartup(typeof(WebApiAuthorize.Startup))]
namespace WebApiAuthorize
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            OAuthConfig(app);
        }
        public void ApiConfig(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional }
                );

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType)); //添加的配置
            app.UseWebApi(config);
        }

        private static void OAuthConfig(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/conntection/gettoken"),
                Provider = new OTWAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10),
                AllowInsecureHttp = true,
            };
            app.UseOAuthBearerTokens(OAuthOptions);
        }

        public class OTWAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            //1.验证客户
            public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {    //此处可以判断client和user　<br>
                 //this.ClientId = clientId;
                 //this.IsValidated = true;
                 //this.HasError = false;
                context.Validated("自定义的clientId");
                return base.ValidateClientAuthentication(context);
            }
            //授权客户
            public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
            {
                List<Claim> lstClaims = new List<Claim>();
                var forms = context.Request.ReadFormAsync().Result["password"];
                lstClaims.Add(new Claim("name", forms));
                lstClaims.Add(new Claim("CustomerId", Guid.NewGuid().ToString()));
                lstClaims.Add(new Claim("UserId", "小崽子"));
                //var ticket = new AuthenticationTicket(new ClaimsIdentity(new[] { new Claim("CustomerId", Guid.NewGuid().ToString()), new Claim("UserId", "小崽子") }, context.Options.AuthenticationType), null);
                var ticket = new AuthenticationTicket(new ClaimsIdentity(lstClaims.ToArray(), context.Options.AuthenticationType), null);
                //return Task.FromResult(0);
                context.Validated(ticket);
                return base.GrantClientCredentials(context);
            }
        }
    }
}
