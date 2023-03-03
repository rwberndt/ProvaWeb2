using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public interface IComandaRepository : IRepository<Comanda>
    {
        IEnumerable<Usuario> GetAll();

        void CadastrarComanda(Comanda comanda);
        Comanda FindById(int id);
    }
}
