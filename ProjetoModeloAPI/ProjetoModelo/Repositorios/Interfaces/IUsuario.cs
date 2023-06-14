using ProjetoModelo.Models;

namespace ProjetoModelo.Repositorios.Interfaces
{
    public interface IUsuario
    {
        Task<List<UsuarioModel>> UsuarioTodos();
        Task<UsuarioModel> UsuarioPorId(int id);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        Task<bool> Remover(int id);
    }
}
