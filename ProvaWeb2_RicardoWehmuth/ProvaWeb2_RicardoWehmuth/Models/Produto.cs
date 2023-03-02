namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Produto : BaseEntity, IValidable
    {
        public Produto()
        {

        }
        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Nome) || Preco == 0)
                return false;
            return true;
        }
    }
}
