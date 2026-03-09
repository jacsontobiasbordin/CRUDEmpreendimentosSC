using CRUDEmpreendimentosSC.Data;
using CRUDEmpreendimentosSC.Enums;
using CRUDEmpreendimentosSC.Models;

namespace CRUDEmpreendimentosSC.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.EmpreendimentosSC.Any())
                return;

            var municipios = new List<string>
            {
                "Joinville","Florianópolis","Blumenau","Chapecó","Itajaí",
                "Criciúma","Jaraguá do Sul","Lages","Rio do Sul","São Joaquim"
            };

            var nomesEmpreendedores = new List<string>
            {
                "Carlos Silva","Ana Costa","Roberto Lima","Juliana Rocha",
                "Pedro Martins","Lucas Pereira","Mariana Souza","Fernando Alves",
                "Paula Mendes","Ricardo Fernandes"
            };

            var observacoes = new List<string>
            {
                "Startup de tecnologia",
                "Loja de materiais",
                "Consultoria empresarial",
                "Produção agrícola",
                "Indústria regional",
                "Serviços especializados",
                "Distribuidora comercial",
                "Empresa de software",
                "Agroindústria",
                "Empresa de serviços"
            };

            var portes = new List<string>
            {
                "Pequeno Porte",
                "Médio Porte",
                "Grande Porte"
            };

            var random = new Random();

            var empreendimentos = new List<EmpreendimentoSC>();

            for (int i = 1; i <= 100; i++)
            {
                var segmento = (Segmento)random.Next(1, 6);
                var municipio = municipios[random.Next(municipios.Count)];
                var empreendedor = nomesEmpreendedores[random.Next(nomesEmpreendedores.Count)];

                var nomeEmpresa = $"{segmento} {municipio} {i}";

                empreendimentos.Add(new EmpreendimentoSC
                {
                    NomeEmpreendimento = nomeEmpresa,
                    NomeEmpreendedor = empreendedor,
                    Municipio = municipio,
                    Segmento = segmento,
                    Email = $"contato{i}@empresa.com",
                    Status = true,
                    Telefone = $"4799999{random.Next(1000, 9999)}",
                    Observacao = observacoes[random.Next(observacoes.Count)],
                    PorteEmpresa = portes[random.Next(portes.Count)],
                    Website = $"www.empresa{i}.com.br"
                });
            }

            context.EmpreendimentosSC.AddRange(empreendimentos);
            context.SaveChanges();
        }
    }
}
