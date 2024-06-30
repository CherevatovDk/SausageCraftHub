using Infrastructure.IRepo;
using Infrastructure1.EFDbContext;
using Infrastructure1.IRepo;

namespace Infrastructure.Repo;

public class UnitOfWork:IUnitOfWork,IDisposable
{
    private readonly ApplicationDbContext _context;
    //private readonly ILogger _logger;
    public IProductRepository Products { get; private set; }

    public UnitOfWork(ApplicationDbContext context, IProductRepository products) //ILoggerFactory logger)
    {
        _context = context;
        Products = products;
        //_logger = logger.CreateLogger("Logs");
    }

    public  async Task<int>  CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
      _context.Dispose();
    }

}