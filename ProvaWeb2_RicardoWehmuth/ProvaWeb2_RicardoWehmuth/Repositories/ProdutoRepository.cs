using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ComandaContext context) : base(context)
        {
        }

        public void SetDeatched(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Detached;
            _context.SaveChanges();
        }
    }
}
