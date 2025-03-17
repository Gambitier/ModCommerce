using AccountService.Domain.Models.Users.DomainModels;
using AccountService.Domain.Models.Users.Dtos;

namespace AccountService.Domain.Interfaces.Repositories;

public interface IUserProfileRepository
{
    Task AddAsync(CreateUserProfileDomainModel createUserProfileDomainModel);
    Task<UserProfileDto?> GetByUserIdAsync(string userId);
    Task ConfirmEmailAsync(ConfirmUserEmailDomainModel confirmUserEmailDomainModel);
}
