using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите логин")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        public string Pwd { get; set; } = string.Empty;

        public List<Message> Messages { get; set; } = new();
    }
}