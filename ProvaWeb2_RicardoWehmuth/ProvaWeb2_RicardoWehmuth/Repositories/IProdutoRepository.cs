using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        void SetDeatched(Produto produto);
    }
}
