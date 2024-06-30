using Infrastructure1.IRepo;

namespace Infrastructure.IRepo;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    Task<int> CompleteAsync();

}