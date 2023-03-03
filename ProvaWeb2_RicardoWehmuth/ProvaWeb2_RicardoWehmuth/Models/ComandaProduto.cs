namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class ComandaProduto
     {
        public ComandaProduto()
        {

        }
        public ComandaProduto(int comandaId,int produtoId,Produto produto)
        {
            ComandaId = comandaId;
            Produto = produto;
            ProdutoId= produtoId;
        }
        public int Id { get; protected set; }
        public int ComandaId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

    }
}
