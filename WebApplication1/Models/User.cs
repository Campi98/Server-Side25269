using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int ID_do_User { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public Perfil? Perfil { get; set; }
        public ICollection<Mensagem> MensagensEnviadas { get; set; } = new HashSet<Mensagem>();
        public ICollection<Mensagem> MensagensRecebidas { get; set; } = new HashSet<Mensagem>();
        public ICollection<Avaliacao> AvaliacoesFeitas { get; set; } = new HashSet<Avaliacao>();
        public ICollection<Avaliacao> AvaliacoesRecebidas { get; set; } = new HashSet<Avaliacao>();

        [ForeignKey("Grupo_de_Viagem")]
        public int? ID_do_Grupo { get; set; }  // Chave estrangeira para Grupo_de_Viagem
        public Grupo_de_Viagem? Grupo { get; set; } 
    }
}
