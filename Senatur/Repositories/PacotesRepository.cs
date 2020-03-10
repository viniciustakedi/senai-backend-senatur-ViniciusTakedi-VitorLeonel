using System.Collections.Generic;
using System.Linq;
using Senatur.Context;
using Senatur.Domains;
using Senatur.Interfaces;

namespace Senatur.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();
        public void Atualizar(int id, Pacotes pacote)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            pacoteBuscado.NomePacote = pacote.NomePacote;
            pacoteBuscado.Descricao = pacote.Descricao;
            pacoteBuscado.DataIda = pacote.DataIda;
            pacoteBuscado.DataVolta = pacote.DataVolta;
            pacoteBuscado.Preco = pacote.Preco;
            pacoteBuscado.Ativo = pacote.Ativo;
            pacoteBuscado.NomeCidade = pacote.NomeCidade;

            ctx.Pacotes.Update(pacoteBuscado);
            ctx.SaveChanges();
        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.Find(id);
        }

        public void Cadastar(Pacotes pacote)
        {
            ctx.Pacotes.Add(pacote);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pacotes pacote = ctx.Pacotes.Find(id);
            ctx.Pacotes.Remove(pacote);
            ctx.SaveChanges();
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

        public List<Pacotes> ListarAtivos()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == true);
        }

        public List<Pacotes> ListarInativos()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == false);
        }

        public List<Pacotes> ListarPorCidade(string cidade)
        {
            return ctx.Pacotes.ToList().FindAll(p => p.NomeCidade == cidade);
        }
    }
}