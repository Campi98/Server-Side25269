using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Viagem
    {
        [Key]
        public int Id_da_Viagem { get; set; }

        [ForeignKey(nameof(Grupo_de_Viagem))]
        [Required(ErrorMessage = "ID do Grupo de Viagem é obrigatório.")]
        public int Id_do_Grupo_de_Viagem { get; set; }

        [StringLength(255, ErrorMessage = "A Fotografia relacionada com a viagem não pode ter mais de 255 caracteres.")]
        public string Fotografia_relacionada_com_a_viagem { get; set; }

        [Required(ErrorMessage = "Destino é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Destino não pode ter mais de 100 caracteres.")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Data de Início é obrigatória.")]
        public DateTime Data_de_Inicio { get; set; }

        [Required(ErrorMessage = "Data de Fim é obrigatória.")]
        public DateTime Data_de_Fim { get; set; }

        [StringLength(500, ErrorMessage = "A Descrição não pode ter mais de 500 caracteres.")]
        public string Descricao { get; set; }

        [StringLength(1000, ErrorMessage = "O Itenerário não pode ter mais de 1000 caracteres.")]
        public string Itenerario { get; set; }

        [StringLength(1000, ErrorMessage = "As Dicas e Recomendações não podem ter mais de 1000 caracteres.")]
        public string Dicas_e_Recomendacoes { get; set; }

        [Range(0, 5, ErrorMessage = "O Rating de Viagem deve estar entre 0 e 5.")]
        public float Rating_de_Viagem { get; set; }
    }
}
