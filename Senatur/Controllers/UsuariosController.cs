using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;

namespace Senatur.Controllers
{

    /// <summary>
    /// Controller responsável pelos endpoints referentes aos jogos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    //indica que ele é um controlador de api
    [ApiController]
    public class UsuariosController : ControllerBase
    {
         /// <summary>
        /// Cria um objeto _usuarioRepository que receberá todos os métodos definidos na interface
        /// </summary>
        private IUsuariosRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        ///     Atualizar usuário passando o Id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizarUsuario"></param>
        /// <returns>Retorna um usuario atualizado</returns>
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios atualizarUsuario)
        {
            _usuarioRepository.Atualizar(id, atualizarUsuario);
            return Ok("Usuário atualizado");

        }

        /// <summary>
        /// Para listar todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _usuarioRepository.Listar();
        }

        /// <summary>
        /// Para cadastrar um novo usuário
        /// </summary>
        /// <param name="NovoUsuario"></param>
        /// <returns>Retorna um usuário cadastrado </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios NovoUsuario)
        {
            _usuarioRepository.Cadastar(NovoUsuario);
            return Ok("Usuário cadastrado com sucesso");
        }


        /// <summary>
        /// Para deletar um Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um usuário deletado</returns>
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