using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Models
{
    public class Grupo_de_Viagem
    {


        [Key]
        public int Id_do_Grupo { get; set; }


        [ForeignKey(nameof(Users))]
        public int AdminUser { get; set; }
        public string Nome_do_Grupo { get; set; }

        public string Destino { get; set; }

        public DateTime Data_de_Inicio { get; set; }

        public DateTime Data_de_Fim { get; set; }

        public string Descricao { get; set; }
    }
}
