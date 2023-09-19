namespace Domain.Exceptions;

public class GeoPointNotFoundException: NotFoundException
{
    public GeoPointNotFoundException(Guid geoPointId)
        : base($"The GeoPoint with the identifier {geoPointId} was not found.")    
    {
    }
}