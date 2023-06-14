using Microsoft.EntityFrameworkCore;
using ProjetoModelo.Data;
using ProjetoModelo.Models;
using ProjetoModelo.Repositorios.Interfaces;

namespace ProjetoModelo.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly PadraoDBContext dbc;

        public UsuarioRepositorio(PadraoDBContext padraoDBContext)
        {
            dbc = padraoDBContext;
        }

        public async Task<UsuarioModel> UsuarioPorId(int id)
        {
            return await dbc.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> UsuarioTodos()
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
            UsuarioModel registro = await UsuarioPorId(id);

            if (registro == null)
            {
                throw new Exception($"Usuário não encontrado, ID:{id}");
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
            UsuarioModel registro = await UsuarioPorId(id);

            if (registro == null)
            {
                throw new Exception($"Usuário não encontrado, ID:{id}");                
            }

            dbc.Usuarios.Remove(registro);
            await dbc.SaveChangesAsync();

            return true;
        }

       
    }
}
