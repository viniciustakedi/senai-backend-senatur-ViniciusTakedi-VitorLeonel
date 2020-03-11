using System.Collections.Generic;
using System.Linq;
using Senatur.Context;
using Senatur.Domains;
using Senatur.Interfaces;

namespace Senatur.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();
        public void Atualizar(int id, Usuarios usuario)
        {
            Usuarios atualizarUsuario = ctx.Usuarios.Find(id);

            atualizarUsuario.Email = usuario.Email;
            atualizarUsuario.Senha = usuario.Senha;

            ctx.Update(atualizarUsuario);
            ctx.SaveChanges();
        }

        
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios userBuscar = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return userBuscar;
        }

        public void Cadastar(Usuarios usuario)
        {
            
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}