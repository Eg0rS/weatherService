using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository.Abstractions;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly Context _dbContext;

    public UserRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.Include(x => x.GeoPoints).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users.Include(x => x.GeoPoints).FirstOrDefaultAsync(x => x.Id == userId);
    }

    public void Insert(User user)
    {
        _dbContext.Users.Add(user);
    }

    public void Remove(User user)
    {
        _dbContext.Users.Remove(user);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}