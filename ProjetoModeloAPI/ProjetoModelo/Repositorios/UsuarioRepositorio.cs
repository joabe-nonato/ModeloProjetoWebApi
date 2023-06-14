using Microsoft.EntityFrameworkCore;
using ProjetoModeloAPI.Data;
using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Repositorios.Interfaces;

namespace ProjetoModeloAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly PadraoDBContext dbc;

        public UsuarioRepositorio(PadraoDBContext padraoDBContext)
        {
            dbc = padraoDBContext;
        }

        public async Task<UsuarioModel> RecuperarPorId(int id)
        {
            return await dbc.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> ListarRegistros()
        {
            return await dbc.Usuarios.ToListAsync();
        }

        
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await dbc.Usuarios.AddAsync(usuario);
            await dbc.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel registro = await RecuperarPorId(id);

            if (registro == null)
            {
                throw new Exception($"Registro não encontrado, ID: {id}");
            }

            registro.Ativo = usuario.Ativo;
            registro.Nome = usuario.Nome;
            registro.Cpf = usuario.Cpf;
            registro.Email = usuario.Email;

            dbc.Usuarios.Update(registro);
            await dbc.SaveChangesAsync();

            return registro;
        }

        public async Task<Boolean> Remover(int id)
        {
            UsuarioModel registro = await RecuperarPorId(id);

            if (registro == null)
            {
                throw new Exception($"Registro não encontrado, ID: {id}");                
            }

            dbc.Usuarios.Remove(registro);
            await dbc.SaveChangesAsync();

            return true;
        }

       
    }
}
