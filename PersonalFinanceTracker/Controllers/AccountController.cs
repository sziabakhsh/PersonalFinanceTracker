using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.DTOs.Account;
using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Mappers;
using PersonalFinanceTracker.Services;

namespace PersonalFinanceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        //private readonly IPasswordHasherService _passwordHasherService;

        public AccountController(ITokenService tokenService, IAuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;
            //_passwordHasherService = passwordHasherService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var appUser = requestDto.ToUser();

            try
            {
                var userTokenDto = await _authService.RegisterAsync(requestDto);
                return Ok(userTokenDto);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
