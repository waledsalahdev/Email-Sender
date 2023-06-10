using Email_Sender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email_Sender.Data
{
    public class MailRequest
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ToEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")] 
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please Enter Message")]
        public string Message { get; set; }

    }
    public class CreateVM
    {
        public IEnumerable<MailRequest> dis { get; set; }
        public MailRequest input { get; set; }

    }
}
