using Microsoft.EntityFrameworkCore;
using NinjaShop.API.Domain;

namespace NinjaShop.Repository
{
public class NinjaContext : DbContext
    {
        public NinjaContext(DbContextOptions<NinjaContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
