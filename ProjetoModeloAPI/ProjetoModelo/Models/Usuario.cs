using ProjetoModeloAPI.Enums;

namespace ProjetoModelo.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public EnumUsuarioTipo Tipo { get; set; }
        public bool Ativo { get; set; }

    }
}
