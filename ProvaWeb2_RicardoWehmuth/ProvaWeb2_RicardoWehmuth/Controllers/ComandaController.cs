using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaWeb2_RicardoWehmuth.Models;
using ProvaWeb2_RicardoWehmuth.Models.DTOs;
using ProvaWeb2_RicardoWehmuth.Repositories;
using ProvaWeb2_RicardoWehmuth.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProvaWeb2_RicardoWehmuth.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;
        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarComandas()
        {
            var result = await _comandaService.BuscarUsuarios();
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result.Exception.Message.ToString());
        }

        [HttpGet, Route("porId")]
        public async Task<IActionResult> BuscarComandasPorId([FromQuery] int id)
        {
            var result = await _comandaService.BuscarComandaPorId(id);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result.Exception.Message.ToString());
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarComand([FromBody] CreateCommandDto comanda)
        {
            var result = await _comandaService.CadastrarComanda(comanda);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result.Exception.Message.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarComanda([FromQuery] int id, [FromBody] UpdateComandaDto comanda)
        {
            var result = await _comandaService.AtualizarComanda(id, comanda);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result.Exception.Message.ToString());
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarComanda([FromQuery] int id)
        {

            var result = await _comandaService.DeletarComanda(id);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result.Exception.Message.ToString());
        }
    }
}
