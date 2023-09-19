using Contracts;

namespace Service.Abstractions;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();

    Task<UserDto> GetByIdAsync(Guid userId);

    Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto);

    Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto);

    Task DeleteAsync(Guid userId);
}