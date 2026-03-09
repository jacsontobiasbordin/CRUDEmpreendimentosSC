using CRUDEmpreendimentosSC.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace CRUDEmpreendimentosSC.Examples
{
    public class EmpreendimentoExample : IExamplesProvider<EmpreendimentoSCDto>
    {
        public EmpreendimentoSCDto GetExamples()
        {
            return new EmpreendimentoSCDto
            {
                NomeEmpreendimento = "Tech Guaramirim",
                NomeEmpreendedor = "João da Silva",
                Municipio = "Guaramirim",
                Segmento = 1,
                Email = "contato@techguaramirim.com",
                Status = true,
                Telefone = "47999999999",
                Observacao = "Startup de tecnologia industrial",
                PorteEmpresa = "Pequeno Porte",
                Website = "www.techguaramirim.com.br"
            };
        }
    }
}
