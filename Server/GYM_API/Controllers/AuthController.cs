
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static GYM_MODELS.Settings.Swagger;

namespace GYM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Handles user sign-in.
        /// </summary>
        [HttpPost("Sign_In")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.Authentication) })]
        public ActionResult<LoginResult> Sign_In([FromBody] LoginModel loginForm)
        {
            LoginResult loginResult = _authService.Login(loginForm);
            HttpContext.Response.Headers.Add("X-Is-Not-ApiResponse", "false");

            return Ok(loginResult);
        }

        /// <summary>
        /// Handles user registration.
        /// </summary>
        [HttpPost("Sign_Up")]
        [SwaggerOperation(Tags = new[] { "Authentication" })]
        public ActionResult<LoginResult> Sign_Up([FromBody] RegisterModel registerModel)
        {
            LoginResult registerResult = _authService.Register(registerModel);
            HttpContext.Response.Headers.Add("X-Is-Not-ApiResponse", "false");
            return Ok(registerResult);
        }
    }
}
