using System.Threading.Tasks;

namespace Repository.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}