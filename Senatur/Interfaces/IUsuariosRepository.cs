using System.Collections.Generic;
using Senatur.Domains;

namespace Senatur.Interfaces
{
    public interface IUsuariosRepository
    {
        Usuarios BuscarPorEmailSenha(string email, string senha);
        void Atualizar(int id, Usuarios usuario);
        void Cadastar(Usuarios usuario);
        void Deletar(int id);
<<<<<<< HEAD
        List<Usuarios> Listar(); 
=======
        List<Usuarios> Listar();
>>>>>>> 3d157059ed12fe9f78e4b5ba22d044128cbe7508
    }
}