using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Usuario : BaseEntity, IValidable
    {
        public Usuario()
        {

        }
        public Usuario(int id,string nomeUsuario)
        {
            Id= id;
            NomeUsuario = nomeUsuario;
        }
        public Usuario(int id, string nomeUsuario, List<Comanda> comandas)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            Comandas= comandas;
        }


        public string NomeUsuario { get; set; }
        
        public virtual List<Comanda> Comandas { get; set; }

        public bool IsValid()
        {
            if(String.IsNullOrEmpty(NomeUsuario))
                return false;
            return true;
        }
    }
}
