using MassTransit;
using Microsoft.Extensions.Logging;
using UserService.Domain.Interfaces.Services;

namespace UserService.Infrastructure.MessageQueue.IdentityService.Events.UserEmailConfirmed;

/// <summary>
/// This is a consumer for the <see cref="UserEmailConfirmedEvent"/>.
/// It is used to handle the event when a user's email is confirmed.
/// </summary>
public class UserEmailConfirmedEventConsumer : IConsumer<UserEmailConfirmedEvent>
{
    private readonly IUserProfileService _userProfileService;
    private readonly ILogger<UserEmailConfirmedEventConsumer> _logger;
    public UserEmailConfirmedEventConsumer(
        IUserProfileService userProfileService,
        ILogger<UserEmailConfirmedEventConsumer> logger)
    {
        _userProfileService = userProfileService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<UserEmailConfirmedEvent> context)
    {
        try
        {
            var message = context.Message;
            _logger.LogInformation(
                "Consuming UserEmailConfirmedEvent for user {UserId}", message.UserId);

            // Implement the logic for handling the email confirmation
            await _userProfileService.ConfirmEmailAsync(
                message.UserId,
                message.Email,
                message.ConfirmedAt);

            _logger.LogInformation(
                "Successfully confirmed email for user {UserId}", message.UserId);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Error processing UserEmailConfirmedEvent for user {UserId}",
                context.Message.UserId);
            throw; // Let MassTransit handle the retry policy
        }
    }
}
