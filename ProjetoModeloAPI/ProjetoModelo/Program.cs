using Microsoft.EntityFrameworkCore;
using ProjetoModelo.Data;
using ProjetoModelo.Repositorios;
using ProjetoModelo.Repositorios.Interfaces;

namespace ProjetoModelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Minhas configurações
                        
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<PadraoDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();

            //builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}