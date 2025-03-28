using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces.Repositories;

public interface IUserProfileRepository
{
    Task AddAsync(UserProfile userProfile);
    Task<UserProfile?> GetByUserIdAsync(string userId);
    Task ConfirmEmailAsync(string email);
}
