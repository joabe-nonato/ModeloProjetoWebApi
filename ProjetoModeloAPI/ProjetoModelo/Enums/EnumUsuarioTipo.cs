using System.ComponentModel;

namespace ProjetoModeloAPI.Enums
{
    public enum EnumUsuarioTipo
    {
        [Description("Administrador")]
        Administrador = 1,
        
        [Description("Profissional")]
        Profissional = 2,

        [Description("Comum")]
        Comum = 3,
    }
}
