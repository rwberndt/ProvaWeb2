namespace ProvaWeb2_RicardoWehmuth.Models.DTOs
{
    public class UpdateComandaDto
    {

        public List<Produto> Produtos { get; set; }


        public bool IsValid()
        {
            return !Produtos.Any();
        }
    }
}
