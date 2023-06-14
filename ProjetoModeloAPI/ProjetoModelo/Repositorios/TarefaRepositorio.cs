using Microsoft.EntityFrameworkCore;
using ProjetoModeloAPI.Data;
using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Repositorios.Interfaces;

namespace ProjetoModeloAPI.Repositorios
{
    public class TarefaRepositorio : ITarefa
    {
        private readonly PadraoDBContext dbc;

        public TarefaRepositorio(PadraoDBContext padraoDBContext)
        {
            dbc = padraoDBContext;
        }

        public async Task<TarefaModel> RecuperarPorId(int id)
        {
            return await dbc.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> ListarRegistros()
        {
            return await dbc.Tarefas.Include(x => x.Usuario).ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel Tarefa)
        {
            await dbc.Tarefas.AddAsync(Tarefa);
            await dbc.SaveChangesAsync();

            return Tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel Tarefa, int id)
        {
            TarefaModel registro = await RecuperarPorId(id);

            if (registro == null)
            {
                throw new Exception($"Registro não encontrado, ID: {id}");
            }

            registro.Nome = Tarefa.Nome;
            registro.Descricao = Tarefa.Descricao;
            registro.Situacao = Tarefa.Situacao;
            registro.UsuarioId = Tarefa.UsuarioId;

            dbc.Tarefas.Update(registro);
            await dbc.SaveChangesAsync();

            return registro;
        }

        public async Task<Boolean> Remover(int id)
        {
            TarefaModel registro = await RecuperarPorId(id);

            if (registro == null)
            {
                throw new Exception($"Registro não encontrado, ID: {id}");
            }

            dbc.Tarefas.Remove(registro);
            await dbc.SaveChangesAsync();

            return true;
        }


    }
}
