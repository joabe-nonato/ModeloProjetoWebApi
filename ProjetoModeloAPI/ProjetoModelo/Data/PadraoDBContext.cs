using Microsoft.EntityFrameworkCore;
using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Data.Map;
using ProjetoModeloAPI.Models;

namespace ProjetoModeloAPI.Data
{
    public class PadraoDBContext : DbContext
    {
        public PadraoDBContext(DbContextOptions<PadraoDBContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        //[criarDbSe]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
