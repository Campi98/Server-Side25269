using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Alojamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public int Capacidade { get; set; }
        public int PrecoPorNoite { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDisponivel { get; set; }
        public string Proprietario { get; set; }
        public string TelefoneProprietario { get; set; }

        [ForeignKey("Viagem")]
        public int ID_da_Viagem { get; set; }

        public Viagem Viagem { get; set; }
    }
}
