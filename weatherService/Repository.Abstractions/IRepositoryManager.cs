namespace Repository.Abstractions;

public interface IRepositoryManager
{
    IGeoPointsRepository GeoPointsRepository { get; }
    IUserRepository UserRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}