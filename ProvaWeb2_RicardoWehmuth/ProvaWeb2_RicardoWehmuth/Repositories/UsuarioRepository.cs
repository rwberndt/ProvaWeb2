using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ComandaContext context) : base(context)
        {
        }
    }
}
