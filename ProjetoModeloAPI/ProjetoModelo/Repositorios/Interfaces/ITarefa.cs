using ProjetoModeloAPI.Models;

namespace ProjetoModeloAPI.Repositorios.Interfaces
{
    public interface ITarefa
    {
        Task<List<TarefaModel>> ListarRegistros();
        Task<TarefaModel> RecuperarPorId(int id);

        Task<TarefaModel> Adicionar(TarefaModel Tarefa);

        Task<TarefaModel> Atualizar(TarefaModel Tarefa, int id);

        Task<bool> Remover(int id);
    }
}
