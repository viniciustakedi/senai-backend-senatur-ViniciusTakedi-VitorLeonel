using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senatur.Domains;
using Senatur.Interfaces;
using Senatur.Repositories;
using Senatur.ViewModels;

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
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuariosRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param "Login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <param>L</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel Usuario)
        {
            // Busca o usuário pelo e-mail e senha
            Usuarios usuarioSelecionado = _usuarioRepository.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioSelecionado == null)
            {
                // Retorna NotFound com uma mensagem de erro
                return NotFound("E-mail ou senha inválidos");
            }

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioSelecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioSelecionado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioSelecionado.IdTipoUsuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai-senatur-VitorLeonel-ViniciusTakedi-key-auth"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                // emissor do token
                audience: "Senatur.WebApi",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            // Retorna Ok com o token
            return Ok( new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
            
        }
    }
}