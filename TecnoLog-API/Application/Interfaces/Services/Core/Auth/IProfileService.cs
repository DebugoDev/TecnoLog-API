namespace Application.Interfaces.Services.Core.Auth;

using Application.Entities;
using Application.Models.Entities;

public interface IProfileService
{
    ProfileDto GetProfileDto(User entity);
}