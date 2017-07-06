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
using Microsoft.Owin.Security.Infrastructure;
using System.Collections.Concurrent;

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
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"), //获取 access_token 授权服务请求地址
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1), //access_token 过期时间   1分钟过期
                Provider = new OTWAuthorizationServerProvider(), //access_token 相关授权服务
                RefreshTokenProvider = new SimpleRefreshTokenProvider() //refresh_token 授权服务
                //调用 示例 ： grant_type=client_credentials&username=liyin&password=123456   获取token
                // 然后在  Header 里面再来 添加 token  就可以通过授权服务了。
            };
            app.UseOAuthBearerTokens(OAuthOptions);
        }


        public class SimpleRefreshTokenProvider : AuthenticationTokenProvider
        {
            private static ConcurrentDictionary<string, string> _refreshTokens = new ConcurrentDictionary<string, string>();

            /// <summary>
            /// 生成 refresh_token
            /// </summary>
            public override void Create(AuthenticationTokenCreateContext context)
            {
                context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
                context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(1);

                context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
                _refreshTokens[context.Token] = context.SerializeTicket();
            }

            /// <summary>
            /// 由 refresh_token 解析成 access_token
            /// </summary>
            public override void Receive(AuthenticationTokenReceiveContext context)
            {
                string value;
                if (_refreshTokens.TryRemove(context.Token, out value))
                {
                    context.DeserializeTicket(value);
                }
            }
        }

        /// <summary>
        /// 授权
        /// </summary>
        public class OTWAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            //1.验证客户
            public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated("自定义的clientId");
                return base.ValidateClientAuthentication(context);
            }

            //授权客户   client 客户端授权模式
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
