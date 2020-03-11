using Microsoft.AspNetCore.Mvc;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;

namespace Senatur.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository { get; set; }

        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacoteRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        [HttpGet("Status/{status}")]
        public IActionResult ListarAtivos(string status)
        {
            if (status == "ativo")
            {
                return Ok(_pacoteRepository.ListarAtivos());
            }
            else if (status == "inativo")
            {
                return Ok(_pacoteRepository.ListarInativos());
            }
            else
            {
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ativo' ou 'inativo'");
            }

        }

        [HttpGet("Cidade/{cidade}")]
        public IActionResult ListarPorCidade(string cidade)
        {
            return Ok(_pacoteRepository.ListarPorCidade(cidade));
        }

        [HttpGet("Preco/{valor}")]
        public IActionResult ListarPorPreco(string valor)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pacotes pacote)
        {
            _pacoteRepository.Cadastar(pacote);
            return Created("Inserido", pacote);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pacotes pacote)
        {
            _pacoteRepository.Atualizar(id, pacote);
            return Ok("Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _pacoteRepository.Deletar(id);
            return Ok("Deletado");
        }

    }
}