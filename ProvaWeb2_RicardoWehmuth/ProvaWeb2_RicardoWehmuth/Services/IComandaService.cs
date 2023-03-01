using Microsoft.AspNetCore.Mvc;
using ProvaWeb2_RicardoWehmuth.Models;

namespace ProvaWeb2_RicardoWehmuth.Services
{

    public interface IComandaService
    {
        Task<ServiceResult> DeletarComanda(int id);
        Task<ServiceResult> BuscarComandas();
        Task<ServiceResult> BuscarComandaPorId(int id);
        Task<ServiceResult> AtualizarComanda(int id, Comanda comanda);
        Task<ServiceResult> CadastrarComanda(Comanda comanda);
    }

}
