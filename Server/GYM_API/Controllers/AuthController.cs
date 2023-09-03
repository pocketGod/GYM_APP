﻿
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Sign_In")]
        public ActionResult Sign_In([FromBody] LoginModel loginForm)
        {
            return Ok(_authService.Login(loginForm));
        }
    }
}