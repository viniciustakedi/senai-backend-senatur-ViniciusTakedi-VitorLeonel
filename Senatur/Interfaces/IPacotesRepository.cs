using System.Collections.Generic;
using Senatur.Domains;

namespace Senatur.Interfaces
{
    public interface IPacotesRepository
    {
        void Atualizar(int id, Pacotes pacote);
        void Cadastar(Pacotes pacote);
        void Deletar(int id);
        List<Pacotes> Listar();
        Pacotes BuscarPorId(int id);
        List<Pacotes> ListarAtivos();
        List<Pacotes> ListarInativos();
        List<Pacotes> ListarPorCidade(string cidade);
    }
}