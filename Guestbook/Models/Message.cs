using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guestbook.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int Id_User { get; set; }

        [Required(ErrorMessage = "Введите текст сообщения")]
        public string MessageText { get; set; } = string.Empty;

        public DateTime MessageDate { get; set; } = DateTime.Now;

        [ForeignKey("Id_User")]
        public User? User { get; set; }
    }
}