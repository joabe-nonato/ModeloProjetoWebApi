using ProjetoModeloAPI.Models;
using ProjetoModeloAPI.Enums;

namespace ProjetoModeloAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public EnumTarefaSituacao Situacao { get; set; }

        public int? UsuarioId { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }

    }
}
