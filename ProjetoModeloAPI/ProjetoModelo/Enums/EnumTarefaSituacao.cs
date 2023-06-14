using System.ComponentModel;

namespace ProjetoModeloAPI.Enums
{
    public enum EnumTarefaSituacao
    {
        [Description("Criado")]
        Criado = 0,

        [Description("Iniciado")]
        Iniciado = 1,

        [Description("Pausado")]
        Pausado = 2,

        [Description("Concluido")]
        Concluido = 3,        

        [Description("Cancelado")]
        Cancelado = 4,
    }
}
