using System;

namespace NinjaShop.API.Domain
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime? Data { get; set; }
        public int Desconto { get; set; }   
        public decimal ValorTotal { get; set; } 
        public int Quantidade { get; set; }          
    
    }
}