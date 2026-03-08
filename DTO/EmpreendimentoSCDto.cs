using System.ComponentModel.DataAnnotations;
using CRUDEmpreendimentosSC.Enums;

namespace CRUDEmpreendimentosSC.DTO
{
    public class EmpreendimentoSCDto
    {
        [Required]
        public string NomeEmpreendimento { get; set; }

        [Required]
        public string NomeEmpreendedor { get; set; }

        [Required]
        public string Municipio { get; set; }

        [Required]
        public int Segmento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }

        // Campos extras

        public string Telefone { get; set; }

        public string Observacao { get; set; }

        public string PorteEmpresa { get; set; }

        public string Website { get; set; }
    }
}
