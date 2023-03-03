namespace ProvaWeb2_RicardoWehmuth.Models.DTOs
{
    public class CreateCommandDto
    {
        public CreateCommandDto()
        {

        }

        

        public CreateCommandDto(int id, Usuario usuario)
        {
            Id = id;
            Usuario = usuario;
            Produtos = new List<Produto>();
        }

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }

        public bool IsValid()
        {
            if (!Usuario.IsValid() || Produtos == null)
                return false;

            return true;
        }
    }
}
