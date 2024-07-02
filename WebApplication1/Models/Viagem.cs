using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Viagem
    {
        [Key]
        public int ID_da_Viagem { get; set; }
        public string Fotografia_relacionada_com_a_viagem { get; set; }
        public string Destino { get; set; }
        public DateTime Data_de_Inicio { get; set; }
        public DateTime Data_de_Fim { get; set; }
        public string Descricao { get; set; }
        public string Itinerario { get; set; }
        public string Dicas_e_Recomendacoes { get; set; }
        public float Rating_da_Viagem { get; set; }

        public ICollection<Alojamento> Alojamentos { get; set; } = new HashSet<Alojamento>();
        public ICollection<Grupo_de_Viagem> Grupos { get; set; } = new HashSet<Grupo_de_Viagem>();
    }
}
