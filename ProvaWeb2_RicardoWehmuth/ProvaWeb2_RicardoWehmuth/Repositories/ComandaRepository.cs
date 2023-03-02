using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Repositories
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(ComandaContext context) : base(context)
        {
        }

        public void CadastrarComanda(Comanda comanda)
        {
            _context.Comandas.Add(comanda);
            _context.SaveChanges();
        }

        public IEnumerable<Comanda> GetAll()
        {
            return _context.Comandas.Include(x=>x.Usuario).Include(x=>x.Produtos).ToList();
        }

    }
}
