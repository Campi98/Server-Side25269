using System.ComponentModel.DataAnnotations;

namespace dWeb2024.Models
{
    public class Users
    {

        public Users()
        {
            ListaMensagens = new HashSet<Mensagem>();
            LIstaAvaliacoes = new HashSet<Avaliacao>();
        }


        [Key]
        public int Id_do_User { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 100 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório.")]
        public string Tipo { get; set; }


        public ICollection<Mensagem> ListaMensagens { get; set; }
        public ICollection<Avaliacao> LIstaAvaliacoes { get; set; }

    }



}
