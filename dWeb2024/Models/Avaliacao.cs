using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id_da_Avaliacao { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "Id do Avaliador é obrigatório.")]
        public int Id_do_Avaliador { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "Id do Avaliado é obrigatório.")]
        public int Id_do_Avaliado { get; set; }

        [Range(1, 5, ErrorMessage = "Classificação deve ser entre 1 e 5.")]
        public int Classificacao { get; set; }

        [StringLength(500, ErrorMessage = "Comentário não pode ter mais que 500 caracteres.")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Data é obrigatória.")]
        public DateTime Data { get; set; }
    }
}
