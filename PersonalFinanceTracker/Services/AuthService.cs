using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.DTOs.Account;
using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using PersonalFinanceTracker.Mappers;


namespace PersonalFinanceTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasherService _passwordHasherService;


        public AuthService(AppDbContext context, ITokenService tokenService, IPasswordHasherService passwordHasherService)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<UserTokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == loginDto.Email);


            if (user == null)
                throw new Exception("Invalid credentials");
            else
            {
                var isValid = _passwordHasherService.VerifyPassword(
                    user.Password,
                    loginDto.Password);

                if (!isValid)
                {
                    throw new Exception("Invalid credentials");
                }
            }


            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = GenerateRefreshToken(user.Id);

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new UserTokenDto
            {
                Email = user.Email,
                Token = accessToken,
                FullName = user.FullName
            };
        }

        public async Task<UserTokenDto> RegisterAsync(RegisterRequestDto requestDto)
        {
            var user = requestDto.ToUser();
            user.Password = _passwordHasherService.HashPassword(requestDto.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = GenerateRefreshToken(user.Id);

            return new UserTokenDto
            {
                Email = user.Email,
                Token = accessToken,
                FullName = user.FullName
            };
        }

        public async Task LogoutAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);

            if (refreshToken == null)
                return;

            refreshToken.RevokedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == token);

            //if (refreshToken == null || !refreshToken.IsActive)
            //    throw new Exception("Invalid refresh token");

            var newAccessToken = _tokenService.CreateToken(refreshToken.User);
            var newRefreshToken = GenerateRefreshToken(refreshToken.UserId);

            refreshToken.RevokedAt = DateTime.UtcNow;

            _context.RefreshTokens.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }

        private RefreshToken GenerateRefreshToken(Guid userId)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiredAt = DateTime.UtcNow.AddDays(7),
                UserId = userId
            };
        }
    }
}
