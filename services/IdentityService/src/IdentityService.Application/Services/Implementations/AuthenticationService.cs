using IdentityService.Application.Models;
using IdentityService.Application.Services.Interfaces;
using IdentityService.Domain.Interfaces.Repositories;

namespace IdentityService.Application.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthenticationService(
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResultDto> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.FindByEmailAsync(email);
        if (user == null)
        {
            return AuthResultDto.Failure("Invalid credentials");
        }

        var isValid = await _userRepository.CheckPasswordAsync(user, password);
        if (!isValid)
        {
            return AuthResultDto.Failure("Invalid credentials");
        }

        var token = _tokenService.GenerateJwtToken(user.Id, email);
        return AuthResultDto.Success(token);
    }

    public async Task<AuthResultDto> RegisterUserAsync(UserDto user, string password)
    {
        var (succeeded, errors, userId) = await _userRepository.CreateAsync(
            user.Email,
            password,
            user.FirstName,
            user.LastName
        );
        if (!succeeded || userId == null)
        {
            return AuthResultDto.Failure(errors.FirstOrDefault() ?? "Registration failed");
        }

        var token = _tokenService.GenerateJwtToken(userId, user.Email);
        return AuthResultDto.Success(token);
    }
}
