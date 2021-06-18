namespace NinjaShop.API.Domain
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemURL { get; set; }
        
    }
}