using Microsoft.AspNetCore.Mvc;
using IdentityService.API.Contracts.Auth;
using IdentityService.Application.Interfaces.Services;
using IdentityService.Application.Models;
using FluentResults.Extensions.AspNetCore;
using MapsterMapper;

namespace IdentityService.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        var dto = _mapper.Map<CreateUserDto>(request);
        var result = await _authService.RegisterUserAsync(dto, request.Password);

        if (result.IsFailed)
            return result.ToActionResult();

        return Ok(_mapper.Map<AuthResponse>(result.Value));
    }

    [HttpPost("token")]
    public async Task<ActionResult<AuthResponse>> Token([FromBody] TokenRequest request)
    {
        var dto = _mapper.Map<TokenRequestDto>(request);
        var result = await _authService.AuthenticateAsync(dto);
        if (result.IsFailed)
            return result.ToActionResult();

        return Ok(_mapper.Map<AuthResponse>(result.Value));
    }

    [HttpPost("token/refresh")]
    public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var result = await _authService.RefreshTokenAsync(request.RefreshToken);
        if (result.IsFailed)
            return result.ToActionResult();

        return Ok(_mapper.Map<AuthResponse>(result.Value));
    }
}
