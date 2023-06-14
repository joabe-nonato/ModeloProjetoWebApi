using Microsoft.EntityFrameworkCore;
using ProjetoModelo.Models;
using ProjetoModeloAPI.Data.Map;

namespace ProjetoModelo.Data
{
    public class PadraoDBContext : DbContext
    {
        public PadraoDBContext(DbContextOptions<PadraoDBContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        //[criarDbSe]

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
