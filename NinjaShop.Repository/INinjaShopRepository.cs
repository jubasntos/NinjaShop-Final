using System.Threading.Tasks;
using NinjaShop.API.Domain;

namespace NinjaShop.Repository
{
    public interface INinjaShopRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

         Task<bool> SaveChangesAsync();

         Task<Cliente> GetClienteAsyncById(int ClienteId);
         Task<Cliente[]> GetAllClienteAsync();

         Task<Produto> GetProdutoAsyncById(int ProdutoId);
         Task<Produto[]> GetAllProdutoAsync();
    }
}