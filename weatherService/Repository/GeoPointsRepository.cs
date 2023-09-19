using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository.Abstractions;

namespace Repository;

public class GeoPointsRepository : IGeoPointsRepository
{
    private readonly Context _dbContext;

    public GeoPointsRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GeoPoint>> GetAllByUserIdAsync(Guid geoPointId)
    {
        return await _dbContext.GeoPoints.Where(x => x.UserId == geoPointId).ToListAsync();
    }

    public async Task<GeoPoint> GetByIdAsync(Guid geoPointId)
    {
        return await _dbContext.GeoPoints.FirstOrDefaultAsync(x => x.Id == geoPointId);
    }

    public void Insert(GeoPoint point)
    {
        _dbContext.GeoPoints.Add(point);
    }

    public void Remove(GeoPoint point)
    {
        _dbContext.GeoPoints.Remove(point);
    }

    public void Update(GeoPoint point)
    {
        _dbContext.GeoPoints.Update(point);
    }
}