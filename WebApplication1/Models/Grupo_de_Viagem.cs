using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Grupo_de_Viagem
    {
        [Key]
        public int ID_do_Grupo { get; set; }
        public string Nome_do_Grupo { get; set; }
        public string Destino { get; set; }
        public DateTime Data_de_Inicio { get; set; }
        public DateTime Data_de_Fim { get; set; }
        public string Descricao { get; set; }

        public ICollection<Viagem> Viagens { get; set; } = new HashSet<Viagem>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
