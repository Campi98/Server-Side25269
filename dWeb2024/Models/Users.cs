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

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Tipo { get; set; }


        public ICollection<Mensagem> ListaMensagens { get; set; }
        public ICollection<Avaliacao> LIstaAvaliacoes { get; set; }

    }



}
