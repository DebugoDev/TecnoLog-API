namespace Application.Mappers;

using System.Text;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Services.Core.Auth;
using Application.Mappers.Primitives;
using Application.Models.Entities;
using Application.Models.Requests.User;

public class UserMapper(IProfileService profileService) : IUserMapper
{
    public UserDto ToDto(User entity)
    {
        return new UserDto(
            entity.Id,
            entity.CreatedAt,
            entity.Code,
            entity.Name,
            entity.UserDepartment?.Name,
            entity.Email,
            entity.Role,
            profileService.GetProfileDto(entity)
        );
    }

    public User FromNewUser(NewUser entity)
    {
        return new User
        {
            Code = entity.Code ?? throw new InternalServerErrorException("UnknownErrorMapping"),
            Name = entity.Name ?? throw new InternalServerErrorException("UnknownErrorMapping"),
            Email = entity.Email,
            Role = entity.Role
        };
    }
}