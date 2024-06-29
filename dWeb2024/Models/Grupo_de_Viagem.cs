using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Grupo_de_Viagem
    {
        [Key]
        public int Id_do_Grupo { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "AdminUser é obrigatório.")]
        public int AdminUser { get; set; }

        [Required(ErrorMessage = "Nome do Grupo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome do Grupo não pode ter mais de 100 caracteres.")]
        public string Nome_do_Grupo { get; set; }

        [Required(ErrorMessage = "Destino é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Destino não pode ter mais de 100 caracteres.")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Data de Início é obrigatória.")]
        public DateTime Data_de_Inicio { get; set; }

        [Required(ErrorMessage = "Data de Fim é obrigatória.")]
        public DateTime Data_de_Fim { get; set; }

        [StringLength(500, ErrorMessage = "A Descrição não pode ter mais de 500 caracteres.")]
        public string Descricao { get; set; }
    }
}
