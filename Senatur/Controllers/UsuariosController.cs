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
        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios atualizarUsuario) //Método que atializa o usuário por Id
        {
            _usuarioRepository.Atualizar(id, atualizarUsuario); //Atualiza um Usuario por id, pegando o método e o objeto instanciado ("_usuarioRepository") no começo do código
            return Ok("Usuário atualizado"); //Caso tenha sucesso retorna uma mensagem "Ok" "Usuário atualizado"

        }

        /// <summary>
        /// Para listar todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários</returns>
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet]
        public IEnumerable<Usuarios> Get() //Método para listar os usuarios
        {
            return _usuarioRepository.Listar(); //Retorna os usuarios 
        }

        /// <summary>
        /// Para cadastrar um novo usuário
        /// </summary>
        /// <param name="NovoUsuario"></param>
        /// <returns>Retorna um usuário cadastrado </returns>
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpPost]
        public IActionResult Cadastrar(Usuarios NovoUsuario) //Método para cadastrar um usuário
        {
            _usuarioRepository.Cadastar(NovoUsuario); //Cadastra um usuario
            return Ok("Usuário cadastrado com sucesso"); //caso tenha sucesso retorna uma mensagem "Ok" "Usuário cadastrado com sucesso"
        }


        /// <summary>
        /// Para deletar um Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um usuário deletado</returns>
        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //Método para deletar
        {
            _usuarioRepository.Deletar(id); //Deleta um usuário por id, pegando o método e o objeto instanciado ("_usuarioRepository") no começo do código
            return Ok("O usuário foi deletado com sucesso"); //Caso tenha sucesso ele retorna uma mensagem "Ok" "O usuário foi deletado com sucesso"
        }
    }
}