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
    [Produces("application/json")]
    
    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Usuario)
        {
            Usuarios usuarioSelecionado = _usuarioRepository.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);

            if (usuarioSelecionado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioSelecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioSelecionado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioSelecionado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai-inlock-VitorLeonel-ViniciusTakedi-key-auth"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi",                // emissor do token
                audience: "InLock.WebApi",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            return Ok( new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}