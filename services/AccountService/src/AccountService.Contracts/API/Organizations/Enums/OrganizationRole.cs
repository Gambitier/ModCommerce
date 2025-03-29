using System.ComponentModel.DataAnnotations;

namespace AccountService.Contracts.API.Organizations.Enums;

public enum OrganizationRole
{
    [Display(Name = "Owner")]
    Owner,

    [Display(Name = "Admin")]
    Admin,

    [Display(Name = "Member")]
    Member
}