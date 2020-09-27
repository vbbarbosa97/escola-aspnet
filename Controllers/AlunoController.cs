using System;
using System.Threading.Tasks;
using escola_aspnet.Data;
using escola_aspnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace escola_aspnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        public AlunoController(IRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _repository.GetAllAlunosAsync(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId)
        {
            try
            {
                var response = await _repository.GetAlunoAsyncById(AlunoId, true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("disciplina/{DisciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int DisciplinaId)
        {
            try
            {
                var response = await _repository.GetAlunosAsyncByDisciplinaId(DisciplinaId, false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repository.Add<Aluno>(aluno);
                await _repository.SaveChangesAsync();
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Delete(int AlunoId, Aluno aluno)
        {
            try
            {
                var response = await _repository.GetAlunoAsyncById(AlunoId, false);
                if (response == null)
                {
                    return NotFound("Aluno não encontrado.");
                }

                _repository.Update(aluno);
                await _repository.SaveChangesAsync();
                return Ok(aluno);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int AlunoId)
        {
            try
            {
                var aluno = await _repository.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null)
                {
                    return NotFound("Aluno não encontrado.");
                }

                _repository.Delete(aluno);
                await _repository.SaveChangesAsync();
                return Ok("Deletado com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}