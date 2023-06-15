using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
namespace HamzilahFoods.Data
{
    public class ContactFormModel
    {

        public string? Name { get; set; } = string.Empty;
        public string? Subject { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Body { get; set; } = string.Empty;
    public IFormFile? Attachment { get; set; }
    }
}
