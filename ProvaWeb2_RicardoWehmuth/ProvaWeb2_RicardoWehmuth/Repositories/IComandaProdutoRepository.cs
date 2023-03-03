using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public interface IComandaProdutoRepository
    {

        IEnumerable<ComandaProduto> BuscarComandaProdutoPorComanda(int ComandaId);

        void Insert(ComandaProduto entity);

        void Update(ComandaProduto entity);
    }
}
