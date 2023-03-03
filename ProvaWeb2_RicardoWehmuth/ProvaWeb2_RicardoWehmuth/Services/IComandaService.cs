using Microsoft.AspNetCore.Mvc;
using ProvaWeb2_RicardoWehmuth.Models;
using ProvaWeb2_RicardoWehmuth.Models.DTOs;

namespace ProvaWeb2_RicardoWehmuth.Services
{

    public interface IComandaService
    {
        Task<ServiceResult> DeletarComanda(int id);
        Task<ServiceResult> BuscarUsuarios();
        Task<ServiceResult> BuscarComandaPorId(int id);
        Task<ServiceResult> AtualizarComanda(int id, UpdateComandaDto comanda);
        Task<ServiceResult> CadastrarComanda(CreateCommandDto comanda);
    }

}
