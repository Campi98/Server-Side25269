using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Perfil
    {
        [Key]
        public int Id_do_Perfil { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "ID do User é obrigatório.")]
        public int Id_do_User { get; set; }

        [Required(ErrorMessage = "Fotografia do User é obrigatória.")]
        [StringLength(255, ErrorMessage = "A Fotografia do User não pode ter mais de 255 caracteres.")]
        public string Fotografia_do_User { get; set; }

        [Required(ErrorMessage = "Interesses de Viagem é obrigatório.")]
        [StringLength(500, ErrorMessage = "Os Interesses de Viagem não podem ter mais de 500 caracteres.")]
        public string Interesses_de_Viagem { get; set; }

        [Required(ErrorMessage = "Destinos Favoritos é obrigatório.")]
        [StringLength(500, ErrorMessage = "Os Destinos Favoritos não podem ter mais de 500 caracteres.")]
        public string Destinos_Favoritos { get; set; }

        [Required(ErrorMessage = "Nível de Experiência em Viagens é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nível de Experiência em Viagens não pode ter mais de 100 caracteres.")]
        public string Nivel_de_Experiencia_em_Viagens { get; set; }
    }
}
