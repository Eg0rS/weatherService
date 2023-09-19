using Domain.Entities;

namespace Repository.Abstractions;

public interface IGeoPointsRepository
{
    Task<IEnumerable<GeoPoint>> GetAllByOwnerIdAsync(Guid userId);
    Task<GeoPoint> GetByIdAsync(Guid userId);
    void Insert(GeoPoint point);
    void Remove(GeoPoint point);
    void Update(GeoPoint point);
}