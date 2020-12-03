using Microsoft.Extensions.Configuration;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Settings
{
    public class UserSettings
    {
        public UserSettings(IConfiguration configuration)
        {
            var userSettingsSection = configuration.GetSection("UserSettings");
            var userSettings = userSettingsSection.GetSection("User");
            var passwordSettings = userSettingsSection.GetSection("Password");
            User = userSettings.Value;
            Password = passwordSettings.Value;
        }
        public string User { get; }
        public string Password { get; }

        public static bool ValidateUser(IConfiguration configuration, string user, string password)
        {
            var settings = new UserSettings(configuration);
            return settings.User == user && settings.Password == password;
        }
    }
}
