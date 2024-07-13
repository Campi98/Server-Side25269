using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ViagemGrupo
    {
        public int ViagemId { get; set; }
        public Viagem? Viagem { get; set; }

        public int GrupoDeViagemId { get; set; }
        public Grupo_de_Viagem? GrupoDeViagem { get; set; }
    }
}
