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
        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            if (pacoteAtualizado.NomePacote != null)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }
            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }
            if (pacoteAtualizado.Preco != pacoteBuscado.Preco)
            {
                pacoteAtualizado.Preco = pacoteBuscado.Preco;
            }
            if (pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }
            if (pacoteAtualizado.DataVolta != null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }
            if (pacoteAtualizado.DataIda != null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }
            if (pacoteAtualizado.Ativo != pacoteBuscado.Ativo)
            {
                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            }
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

        public List<Pacotes> ListarPorPrecoAscendente(string valor)
        {
            return ctx.Pacotes.OrderBy(p => p.Preco).ToList();
        }

        public List<Pacotes> ListarPorPrecoDescendente(string valor)
        {
            return ctx.Pacotes.OrderByDescending(p => p.Preco).ToList();
        }
    }
}