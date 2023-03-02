namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Comanda : BaseEntity, IValidable
    {
        public Comanda()
        {

        }
        public Comanda(int id, Usuario usuario, List<Produto> produtos)
        {
            Id = id;
            Usuario = usuario;
            Produtos = produtos;
        }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Produto> Produtos { get;  set; }

        public bool IsValid()
        {
            if (!Usuario.IsValid() || Produtos == null)
                return false;

            return true;
        }
    }
}
