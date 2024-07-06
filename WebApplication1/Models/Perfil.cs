using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Perfil
    {
        [Key]
        public int ID_do_Perfil { get; set; }

        [ForeignKey("User")]
        public int ID_do_User { get; set; }
        public string Fotografia_do_User { get; set; }
        public string Interesses_de_Viagem { get; set; }
        public string Destinos_Favoritos { get; set; }
        public string Nivel_de_Experiencia_em_Viagens { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
