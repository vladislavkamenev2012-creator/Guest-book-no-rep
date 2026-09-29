using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Логин обязателен")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}