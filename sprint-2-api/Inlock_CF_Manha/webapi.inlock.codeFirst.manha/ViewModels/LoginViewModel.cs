using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codeFirst.manha.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="O nome do campo Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="O nome do campo Senha é obrigatório")]
        public string? Senha { get; set; }
    }
}
