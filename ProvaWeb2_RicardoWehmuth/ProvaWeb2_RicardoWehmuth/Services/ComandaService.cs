using ProvaWeb2_RicardoWehmuth.Models;
using ProvaWeb2_RicardoWehmuth.Repositories;

namespace ProvaWeb2_RicardoWehmuth.Services
{
    public class ComandaService : IComandaService
    {

        private readonly IComandaRepository _comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<ServiceResult> AtualizarComanda(int id, Comanda comanda)
        {
            if (!ValdateId(id))
                return ServiceResult.Failure(new ArgumentException("Id inválido"));
            try
            {
                _comandaRepository.Update(comanda);
                return ServiceResult<Comanda>.Success(comanda);
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }


        public async Task<ServiceResult> BuscarComandaPorId(int id)
        {
            if (!ValdateId(id))
                return ServiceResult.Failure(new ArgumentException("Id inválido"));

            var comanda = _comandaRepository.Find(id);

            return ServiceResult<Comanda>.Success(comanda);
        }

        public async Task<ServiceResult> BuscarComandas()
        {
            try
            {
                var comandas = _comandaRepository.GetAll();

                return ServiceResult<Comanda>.Success(comandas);

            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }

        public async Task<ServiceResult> CadastrarComanda(Comanda comanda)
        {
            if (!comanda.IsValid())
                return ServiceResult.Failure(new ArgumentException("Comanda inválida"));
            try
            {
                _comandaRepository.CadastrarComanda(comanda);

                return ServiceResult<Comanda>.Success(comanda);
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }

        public async Task<ServiceResult> DeletarComanda(int id)
        {
            if (!ValdateId(id))
                return ServiceResult.Failure(new ArgumentException("Id inválido"));
            var comanda = _comandaRepository.Find(id);

            try
            {
                _comandaRepository.Delete(comanda);

                return ServiceResult.Success(null, "Comanda removida");
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }


        public bool ValdateId(int id)
        {
            if (id <= 0)
                return false;
            return true;
        }
    }
}
