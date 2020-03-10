using Microsoft.AspNetCore.Mvc;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;

namespace Senatur.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller")]

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

        [HttpGet("{status}")]
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

        [HttpGet("/{cidade}")]
        public IActionResult ListarInativos(string cidade)
        {
            return Ok(_pacoteRepository.ListarPorCidade(cidade));
        }

        [HttpGet("{cidade}")]
        public IActionResult ListarPorCidade(string cidade)
        {
            return Ok(_pacoteRepository.ListarPorCidade(cidade));
        }

        [HttpPost]
        public IActionResult Cadastrar(Pacotes pacote)
        {
            return Created("Inserido", pacote);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, Pacotes pacote)
        {
            _pacoteRepository.Atualizar(id, pacote);
            return Ok("Atualizado");
        }


    }
}