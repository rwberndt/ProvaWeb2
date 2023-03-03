namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Comanda : BaseEntity, IValidable
    {
        public Comanda()
        {

        }
        public Comanda(int id, Usuario usuario)
        {
            Id = id;
            Usuario = usuario;
            Produtos = new List<ComandaProduto>();
        }
        public Comanda(int id, Usuario usuario, List<ComandaProduto> produtos)
        {
            Id = id;
            Usuario = usuario;
            Produtos = produtos;
        }
        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual List<ComandaProduto>? Produtos { get;  set; }

        public bool IsValid()
        {
            if (!Usuario.IsValid() || Produtos == null)
                return false;

            return true;
        }

    }
}
