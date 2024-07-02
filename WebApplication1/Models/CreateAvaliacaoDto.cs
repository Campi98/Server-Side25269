using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateAvaliacaoDto
    {
        [Required]
        public int ID_do_Avaliador { get; set; }

        [Required]
        public int ID_do_Avaliado { get; set; }

        [Required]
        public int Classificacao { get; set; }

        [Required]
        public string Comentario { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
