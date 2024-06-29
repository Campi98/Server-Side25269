using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Mensagem
    {
        public Mensagem()
        {
            ListaUsers = new HashSet<Users>();
        }

        [Key]
        public int Id_da_Mensagem { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "Remetente é obrigatório.")]
        public int Id_do_Remetente { get; set; }

        [ForeignKey(nameof(Users))]
        [Required(ErrorMessage = "Destinatário é obrigatório.")]
        public int Id_do_Destinatario { get; set; }

        [Required(ErrorMessage = "Conteúdo é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O Conteúdo não pode ter mais de 1000 caracteres.")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Data e Hora são obrigatórias.")]
        public DateTime Data_e_Hora { get; set; }

        [Required(ErrorMessage = "Fotografia do User é obrigatória.")]
        public int Fotografia_do_User { get; set; }

        public ICollection<Users> ListaUsers { get; set; }
    }
}
