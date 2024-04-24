using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public int Id_do_Remetente { get; set; }

        [ForeignKey(nameof(Users))]
        public int Id_do_Destinatario { get; set; }

        public string Conteudo { get; set; }

        public DateTime Data_e_Hora { get; set; }

        public int Fotografia_do_User { get; set; }


        public ICollection<Users> ListaUsers { get; set; }
    }
}
