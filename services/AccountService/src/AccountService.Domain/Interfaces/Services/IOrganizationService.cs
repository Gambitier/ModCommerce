using AccountService.Domain.Models.Organizations.DomainModels;
using AccountService.Domain.Models.Organizations.Dtos;
using FluentResults;
namespace AccountService.Domain.Interfaces.Services;

public interface IOrganizationService
{
    Task<Result<Guid>> CreateOrganizationAsync(string userId, CreateOrganizationDomainModel createOrganizationDomainModel);
    Task<Result<OrganizationDto>> GetByIdAsync(Guid id);
}
