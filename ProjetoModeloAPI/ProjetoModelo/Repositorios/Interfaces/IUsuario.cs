using ProjetoModeloAPI.Models;

namespace ProjetoModeloAPI.Repositorios.Interfaces
{
    public interface IUsuario
    {
        Task<List<UsuarioModel>> ListarRegistros();
        Task<UsuarioModel> RecuperarPorId(int id);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        Task<bool> Remover(int id);
    }
}
