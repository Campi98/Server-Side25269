using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Models
{
    public class Viagem
    {

        [Key]
        public int Id_da_Viagem { get; set; }

        [ForeignKey(nameof(Grupo_de_Viagem))]
        public int Id_do_Grupo_de_Viagem { get; set; }

        public string Fotografia_relacionada_com_a_viagem { get; set; }

        public string Destino { get; set; }

        public DateTime Data_de_Inicio { get; set; }

        public DateTime Data_de_Fim { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Itenerario { get; set; }

        public string Dicas_e_Recomendacoes { get; set; }

        public float Rating_de_Viagem { get; set; }


    }
}
