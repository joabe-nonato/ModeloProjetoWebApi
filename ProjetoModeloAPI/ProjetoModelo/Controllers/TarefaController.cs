using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Repositorios.Interfaces;

namespace ProjetoModeloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefa _Tarefa;
        public TarefaController(ITarefa Tarefa)
        {
            _Tarefa = Tarefa;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> TodosTarefas()
        {
            List<TarefaModel> registros = await _Tarefa.ListarRegistros();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> TarefaPorID(int id)
        {
            TarefaModel registro = await _Tarefa.RecuperarPorId(id);
            return Ok(registro);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<TarefaModel>> Adicionar([FromBody] TarefaModel gravar)
        {
            TarefaModel registro = await _Tarefa.Adicionar(gravar);

            return Ok(registro);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel gravar, int id)
        {
            TarefaModel registro = await _Tarefa.Atualizar(gravar, id);

            return Ok(registro);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<ActionResult<TarefaModel>> Remover(int id)
        {
            Boolean registro = await _Tarefa.Remover(id);

            return Ok(registro);
        }

    }
}
