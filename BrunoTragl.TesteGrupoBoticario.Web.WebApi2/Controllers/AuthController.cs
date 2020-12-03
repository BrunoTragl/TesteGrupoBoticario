using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Configurations;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models;
using BrunoTragl.TesteGrupoBoticario.Web.WebApi.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AuthController : MainController
    {
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        public AuthController(ILogger<MainController> logger,
                              IConfiguration configuration,
                              IOptions<AppSettings> appSettings)
            : base(logger)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetToken(UserModel userModel)
        {
            try
            {
                if (UserSettings.ValidateUser(_configuration, userModel.User, userModel.Password))
                    return Ok(JwtConfiguration.GenerateJwtToken(_appSettings));
                
                return NotFound("Invalid username or password");
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }
    }
}
