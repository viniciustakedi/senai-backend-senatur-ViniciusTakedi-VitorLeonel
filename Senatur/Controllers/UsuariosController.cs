using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;

namespace Senatur.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        //Atualizar usuário passando o Id na url
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios atualizarUsuario)
        {
            _usuarioRepository.Atualizar(id, atualizarUsuario);
            return Ok("Usuário atualizado");

        }

        //Para listar todos os usuários
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _usuarioRepository.Listar();
        }

        //Para cadastrar um novo usuário
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios NovoUsuario)
        {
            _usuarioRepository.Cadastar(NovoUsuario);
            return Ok("Usuário cadastrado com sucesso");
        }


        //Para deletar um Usuário
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("O usuário foi deletado com sucesso");
        }
    }
}