using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Settings;
//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddConfiguration(this IServiceCollection services) //IConfiguration configuration
        {
            //var appSettingsSection = configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //});
        }
    }
}
