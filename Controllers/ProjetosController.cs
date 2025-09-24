using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        // GET: api/Projetos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var projetos = _projetoRepository.Listar();
                return Ok(projetos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao listar projetos", error = ex.Message });
            }
        }

        // GET: api/Projetos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var projeto = _projetoRepository.BuscarPorId(id);
                if (projeto == null)
                {
                    return NotFound(new { message = "Projeto não encontrado" });
                }
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao buscar projeto", error = ex.Message });
            }
        }

        // POST: api/Projetos
        [HttpPost]
        public IActionResult Post([FromBody] Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);
                return StatusCode(201); // Created
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao cadastrar projeto", error = ex.Message });
            }
        }

        // PUT: api/Projetos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Projeto projetoAtualizado)
        {
            try
            {
                var existingProject = _projetoRepository.BuscarPorId(id);
                if (existingProject == null)
                {
                    return NotFound(new { message = "Projeto não encontrado" });
                }

                _projetoRepository.Atualizar(id, projetoAtualizado);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar projeto", error = ex.Message });
            }
        }

        // DELETE: api/Projetos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingProject = _projetoRepository.BuscarPorId(id);
                if (existingProject == null)
                {
                    return NotFound(new { message = "Projeto não encontrado" });
                }

                _projetoRepository.Deletar(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao deletar projeto", error = ex.Message });
            }
        }
    }
}