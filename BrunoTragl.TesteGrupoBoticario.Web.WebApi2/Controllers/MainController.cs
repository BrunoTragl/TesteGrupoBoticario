using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        protected IActionResult OkResponse(object data = null)
        {
            try
            {
                _logger.LogInformation("resourse requested", data);
                return Ok(new
                {
                    data,
                    requested = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }

        protected IActionResult BadRequestResponse(object errors = null, object request = null, string resource = null)
        {
            try
            {
                string logMessage = "bad request";
                
                if (!string.IsNullOrEmpty(resource))
                    logMessage += $" of resource {resource}";

                _logger.LogInformation(logMessage, new
                { 
                    request,
                    errors
                });

                return BadRequest(new
                {
                    errors,
                    requested = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(ex);
            }
        }

        protected IActionResult InternalServerErrorResponse(Exception exception)
        {
            try
            {
                _logger.LogError("requested resource", GetExceptionMessages(exception));
                return StatusCode(500, "An error occurred during the requested resource process");
            }
            catch
            {
                return StatusCode(500, "An error occurred during the requested resource process");
            }
        }

        private ICollection<string> GetExceptionMessages(Exception ex)
        {
            ICollection<string> excetionMessage = new List<string>();
            excetionMessage.Add(ex.Message);
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                excetionMessage.Add(ex.InnerException.Message);
            return excetionMessage;
        }
    }
}
