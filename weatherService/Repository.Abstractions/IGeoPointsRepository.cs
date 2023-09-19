using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Abstractions;

public interface IGeoPointsRepository
{
    Task<IEnumerable<GeoPoint>> GetAllByUserIdAsync(Guid geoPointId);
    Task<GeoPoint> GetByIdAsync(Guid geoPointId);
    void Insert(GeoPoint point);
    void Remove(GeoPoint point);
    void Update(GeoPoint point);
}