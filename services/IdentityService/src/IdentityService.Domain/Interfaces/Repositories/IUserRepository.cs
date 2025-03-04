using FluentResults;
using IdentityService.Domain.Models;

namespace IdentityService.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<Result<UserDomainModel>> CreateAsync(string username, string email, string password);
    Task<Result<bool>> IsEmailConfirmedAsync(string usernameOrEmail);
    Task<Result<UserDomainModel>> VerifyUserPasswordAsync(string usernameOrEmail, string password);
    Task<Result<UserDomainModel>> FindByEmailAsync(string email);
    Task<Result<IEnumerable<UserDomainModel>>> GetAllAsync();
    Task<Result<UserDomainModel>> FindByIdAsync(string userId);
    Task<Result<UserDomainModel>> ConfirmEmailAsync(string email, string token);
    Task<Result<string>> GenerateEmailConfirmationTokenAsync(string email);
}
