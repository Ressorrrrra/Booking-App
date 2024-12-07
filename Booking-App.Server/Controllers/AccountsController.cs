using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;


        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(request);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Добавлен новый пользователь" });
                }
                else
                {
                    var errorMsg = new
                    {
                        message = "Не удалось зарегистрировать пользователя",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return BadRequest(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return BadRequest(errorMsg);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LogIn(request);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Unauthorized(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return BadRequest(errorMsg);
            }
        }

        [HttpPost("logoff")]
        public async Task<IActionResult> LogOff()
        {
            if (await _userService.LogOff(HttpContext.User))
            {
                return Ok("Выполнен выход");
            }
            else
            {
                return Unauthorized(new { message = "Сначала выполните вход" });
            }
        }

        [HttpPost("isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            var user = await _userService.IsAuthenticated(HttpContext.User);
            if (user == null)
            {
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            else
            {
                return Ok(user);
            }

        }
    }
}
