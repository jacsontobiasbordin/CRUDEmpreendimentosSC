using System.ComponentModel.DataAnnotations;

namespace CRUDEmpreendimentosSC.Models
{
    public class EmpreendimentoSC
    {
        public int Id { get; set; }

        [Required]
        public string NomeEmpreendimento { get; set; }

        [Required]
        public string NomeEmpreendedor { get; set; }

        [Required]
        public string Municipio { get; set; }

        [Required]
        public string Segmento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }

        // Campos extras
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string Telefone { get; set; }

        public string Observacao { get; set; }

        public string PorteEmpresa { get; set; }

        public string Website { get; set; }
    }
}
