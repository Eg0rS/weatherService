using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Mapster;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;

    public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _repositoryManager.UserRepository.GetAllAsync();

        var userDto = users.Adapt<IEnumerable<UserDto>>();

        return userDto;
    }

    public async Task<UserDto> GetByIdAsync(Guid userId)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var userDto = user.Adapt<UserDto>();

        return userDto;
    }

    public async Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto)
    {
        var user = userForCreationDto.Adapt<User>();

        _repositoryManager.UserRepository.Insert(user);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();

        return user.Adapt<UserDto>();
    }

    public async Task UpdateAsync(Guid userId, UserForUpdateDto userForUpdateDto)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        user.Name = userForUpdateDto.Name;
        user.DateOfBirth = userForUpdateDto.DateOfBirth;
        user.Address = userForUpdateDto.Address;
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        _repositoryManager.UserRepository.Remove(user);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}