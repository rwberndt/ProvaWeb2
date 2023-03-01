namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Usuario : BaseEntity, IValidable
    {
        public Usuario(int id,string nomeUsuario)
        {
            Id= id;
            NomeUsuario = nomeUsuario;
        }

        public string NomeUsuario { get; set; }

        public bool IsValid()
        {
            if(String.IsNullOrEmpty(NomeUsuario))
                return false;
            return true;
        }
    }
}
