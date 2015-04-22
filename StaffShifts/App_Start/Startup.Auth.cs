using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace StaffShifts
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            //{
            //    ClientId = "602303626389-ksfkji12i5p5pg1vgac350lfo9aqmn99.apps.googleusercontent.com",
            //    ClientSecret = "nt2TAvMdnWWuRM25jePPtCyO"
            //});
            //below details are for local host
            {
                ClientId = "602303626389-tofaou6b69voruphqcr75l4ump5mvatf.apps.googleusercontent.com",
                ClientSecret = "yhneuQLyyfkn3LahDzJiBHdU"
            });
            //{
            //    ClientId = "745758001127-84v8k3eetk0c8df56f5u6oj4rk3atnbu.apps.googleusercontent.com",
            //    ClientSecret = "efATD24XoTZQPilgAmSGhis6"
            //});
        }
    }
}