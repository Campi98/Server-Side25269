using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dWeb2024.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Base64String { get; set; }
    }

}
