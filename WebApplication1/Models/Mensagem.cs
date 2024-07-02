using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Mensagem
    {
        [Key]
        public int ID_da_Mensagem { get; set; }

        [ForeignKey("Remetente")]
        public int ID_do_Remetente { get; set; }

        [ForeignKey("Destinatario")]
        public int ID_do_Destinatario { get; set; }

        public string Conteudo { get; set; }
        public DateTime Data_e_Hora { get; set; }

        public User Remetente { get; set; }
        public User Destinatario { get; set; }
    }
}
