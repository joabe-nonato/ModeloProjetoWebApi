﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Repositorios.Interfaces;

namespace ProjetoModeloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> TodosUsuarios()
        {
            List<UsuarioModel> registros = await _usuario.ListarRegistros();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> UsuarioPorID(int id)
        {
            UsuarioModel registro = await _usuario.RecuperarPorId(id);
            return Ok(registro);
        }

        [HttpPost("Adicionar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel gravar)
        {
            UsuarioModel registro = await _usuario.Adicionar(gravar);

            return Ok(registro);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel gravar, int id)
        {
            UsuarioModel registro = await _usuario.Atualizar(gravar, id);

            return Ok(registro);
        }

        [HttpDelete("Remover/{id}")]
        public async Task<ActionResult<UsuarioModel>> Remover(int id)
        {
            Boolean registro = await _usuario.Remover(id);

            return Ok(registro);
        }

    }
}
