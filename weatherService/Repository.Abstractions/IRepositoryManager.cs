namespace Repository.Abstractions;

public class IRepositoryManager
{
    IGeoPointsRepository GeoPointsRepository { get; }
    IUserRepository UserRepository { get; }
}