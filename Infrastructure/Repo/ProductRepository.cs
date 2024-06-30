using ApplicationCore.Services;
using Infrastructure1.EFDbContext;
using Infrastructure1.IRepo;
using Infrastructure1.Models;

namespace Infrastructure1.Repo;

public class ProductRepository:GenericRepository<Product>,IProductRepository
{
    public ProductRepository(ApplicationDbContext db):base(db)
    {
        
        
    }
    
}