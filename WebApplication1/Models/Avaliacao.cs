using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Avaliacao
    {
        [Key]
        public int ID_da_Avaliacao { get; set; }

        [ForeignKey("Avaliador")]
        public int ID_do_Avaliador { get; set; }

        [ForeignKey("Avaliado")]
        public int ID_do_Avaliado { get; set; }

        public int Classificacao { get; set; }
        public string Comentario { get; set; }
        public DateTime Data { get; set; }

        public User Avaliador { get; set; }
        public User Avaliado { get; set; }
    }
}
