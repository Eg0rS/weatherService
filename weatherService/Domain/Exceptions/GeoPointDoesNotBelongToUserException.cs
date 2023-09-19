namespace Domain.Exceptions;

public class GeoPointDoesNotBelongToUserException: BadRequestException
{
    public GeoPointDoesNotBelongToUserException(Guid userId, Guid  geoPointId)
        : base($"The  GeoPoint with the identifier {geoPointId} does not belong to the user with the identifier {userId}")
    {
    }
}