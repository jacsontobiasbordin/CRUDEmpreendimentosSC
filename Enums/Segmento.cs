using System.ComponentModel;

namespace CRUDEmpreendimentosSC.Enums
{
    public enum Segmento
    {
        [Description("Tecnologia")]
        Tecnologia = 1,

        [Description("Comércio")]
        Comercio = 2,

        [Description("Indústria")]
        Industria = 3,

        [Description("Serviços")]
        Servicos = 4,

        [Description("Agronegócio")]
        Agronegocio = 5
    }
}
