namespace Application.Models.Entities;

using Application.Enums;
using Application.Models.Entities.Primitives;

public record UserDto(
    Guid Id,
    DateTime CreatedAt,
    short Code,
    string Name,
    string? UserDepartment,
    string? Email,
    ERole Role,
    ProfileDto Profile
) : BaseDto(Id, CreatedAt);