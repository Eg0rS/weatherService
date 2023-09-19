using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Abstractions;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid userId);
    void Insert(User user);
    void Remove(User user);
    void Update(User user);
}