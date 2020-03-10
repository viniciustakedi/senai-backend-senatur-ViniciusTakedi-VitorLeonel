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
            throw new System.NotImplementedException();
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios userBuscar = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return userBuscar;
        }

        public void Cadastar(Usuarios usuario)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}