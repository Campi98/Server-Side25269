using Microsoft.AspNetCore.Http;

namespace dWeb2024.Models
{
    public class FileSubmitModel
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}