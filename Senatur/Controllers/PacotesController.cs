using Microsoft.AspNetCore.Mvc;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;

namespace Senatur.Controllers
{
    /// <summary>
    /// Controller responsável pelo Login
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    //Define que ele é um controle de api
    [ApiController]
    public class PacotesController : ControllerBase
    {   
        /// <summary>
        /// Cria um objeto _pacoteRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPacotesRepository _pacoteRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }


        /// <summary>
        /// Para listar os pacotes
        /// </summary>
        /// <returns>Retorna uma lista com os pacotes/</returns>
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet]
        public IActionResult Listar() //método para a lista
        {
            return Ok(_pacoteRepository.Listar()); //Retorna a lista de pacotes
        }

        /// <summary>
        /// Para listar os pacotes por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o pacote que foi buscado pela id</returns>
        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id) //Método para listar o pacote buscado por Id
        {
            return Ok(_pacoteRepository.BuscarPorId(id)); //Retorna o pacote
        }

        /// <summary>
        /// Para listar os pacotes ativos 
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Para listar todos os pacotes que estão ativos</returns>
        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet("Status/{status}")]
        public IActionResult ListarAtivos(string status) //Método para listar os ativos 
        {   
            if (status == "ativo") //Verifica os pacotes "ativo"
            {
                return Ok(_pacoteRepository.ListarAtivos()); //Retorna os pacotes ativos
            }
            else if (status == "inativo") //Verifica os pacotes "inativos"
            {
                return Ok(_pacoteRepository.ListarInativos()); //Lista os pacotes inativos
            }
            else //se a maneira que foi solicitada não a correta 
            {
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ativo' ou 'inativo'"); //Retorna uma mensagem de erro e a maneira correta
            }
        }

        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet("Cidade/{cidade}")]
        public IActionResult ListarPorCidade(string cidade) //Método de listar a cidade buscada
        {
            return Ok(_pacoteRepository.ListarPorCidade(cidade)); //Retorna a cidade buscada pelo usuário
        }   

        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpGet("Preco/{valor}")]
        public IActionResult ListarPorPreco(string valor) //Método de listar por preço
        {
<<<<<<< HEAD
            return Ok();    //Retorna um Ok
=======
           if (valor == "barato")
            {
                return Ok(_pacoteRepository.ListarPorPrecoAscendente(valor));
            }
            else if (valor == "caro")
            {
                return Ok(_pacoteRepository.ListarPorPrecoDescendente(valor));
            }
            else
            {
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'caro' ou 'barato'");
            }
>>>>>>> 88efec9dbeec0cc42ab2688f1c66da9594a7b8f4
        }

        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpPost]
        public IActionResult Cadastrar(Pacotes pacote) //Método para cadastrar um usuário
        {
            _pacoteRepository.Cadastar(pacote); //Cadastra um usuário
            return Created("Inserido", pacote); //Caso tenha sucesso, retorna uma mensagem "Created" "Inserido"
        }

        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pacotes pacote) //Método para atualizar um pacote
        {
            _pacoteRepository.Atualizar(id, pacote); //Atualiza um pacote por id, pegando o método e o objeto instanciado ("_pacoteRepository") no começo do código
            return Ok("Atualizado");
        }

        [Authorize(Roles = "1")] //Indica a role que tem a permissão para fazer a ação
        [ProducesResponseType(StatusCodes.Status200OK)] //A resposta de sucesso será "Status200Ok"
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) //Método para deletar um pacote
        {
            _pacoteRepository.Deletar(id); //Deleta um pacote por id, pegando o método e o objeto instanciado ("_pacoteRepository") no começo do código 
            return Ok("Deletado"); //Caso tenha sucesso, retorna uma mensagem de "Ok" "Deletado"
        }

    }
}