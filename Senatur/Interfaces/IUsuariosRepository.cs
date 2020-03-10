using Senatur.Domains;

namespace Senatur.Interfaces
{
    public interface IUsuariosRepository
    {
        Usuarios BuscarPorEmailSenha(string email, string senha);
        void Atualizar(int id, Usuarios usuario);
        void Cadastar(Usuarios usuario);
        void Deletar(int id);
    }
}