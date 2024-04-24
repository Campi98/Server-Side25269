using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Models
{
    public class Avaliacao
    {

        [Key]
        public int Id_da_Avaliacao { get; set; }

        [ForeignKey(nameof(Users))]
        public int Id_do_Avaliador { get; set; }
        public int Id_do_Avaliado { get; set; }

        public int Classificacao { get; set; }

        public string Comentario { get; set; }

        public DateTime Data { get; set; }

    }
}
