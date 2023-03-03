using Microsoft.EntityFrameworkCore;
using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public class ComandaProdutoRepository :  IComandaProdutoRepository
    {
        private readonly ComandaContext _context;
        public ComandaProdutoRepository(ComandaContext context) 
        {
            _context = context;
        }

        public IEnumerable<ComandaProduto> BuscarComandaProdutoPorComanda(int comandaId)
        {
            return _context.ComandaProdutos.Where(x => x.ComandaId == comandaId).Include(x=>x.Produto);
        }

        public void Insert(ComandaProduto entity)
        {
            _context.ComandaProdutos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ComandaProduto entity)
        {
            _context.ComandaProdutos.Update(entity);
            _context.SaveChanges();
        }
    }
}
