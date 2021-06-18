using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NinjaShop.API.Domain;

namespace NinjaShop.Repository
{
    public class NinjaShopRepository : INinjaShopRepository
    {
        public readonly NinjaContext _context;

        public NinjaShopRepository(NinjaContext context)
        {
            _context = context;
        }

        // GERALZÃO

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //CLIENTES

        public async Task<Cliente> GetClienteAsyncById(int ClienteId)
        {
            IQueryable<Cliente> query = _context.Clientes;
               
            query = query.OrderByDescending(c => c.ClienteId)
                        .Where(c => c.ClienteId == ClienteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente[]> GetAllClienteAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.AsNoTracking().OrderByDescending(c => c.ClienteId);

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync())  > 0;
        }

        //PRODUTOS

         public async Task<Produto> GetProdutoAsyncById(int ProdutoId)
        {
            IQueryable<Produto> query = _context.Produtos;
               
            query = query.OrderByDescending(c => c.ProdutoId)
                        .Where(c => c.ProdutoId == ProdutoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto[]> GetAllProdutoAsync()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderByDescending(c => c.ProdutoId);

            return await query.ToArrayAsync();
        }
         
    }
}