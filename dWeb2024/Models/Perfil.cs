using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Models
{
    public class Perfil
    {

        [Key]
        public int Id_do_Perfil { get; set; }

        [ForeignKey(nameof(Users))]
        public int Id_do_User { get; set; }

        public string Fotografia_do_User { get; set; }

        public string Interesses_de_Viagem { get; set; }

        public string Destinos_Favoritos { get; set; }

        public string Nivel_de_Experiencia_em_Viagens { get; set; }

    }
}
