using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            _context.Projetos.Add(novoProjeto);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Projeto projetoAtualizado)
        {
            var projetoExistente = _context.Projetos.Find(id);
            if (projetoExistente != null)
            {
                projetoExistente.NomeDoProjeto = projetoAtualizado.NomeDoProjeto;
                projetoExistente.Area = projetoAtualizado.Area;
                projetoExistente.Status = projetoAtualizado.Status;

                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var projeto = _context.Projetos.Find(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                _context.SaveChanges();
            }
        }
    }
}