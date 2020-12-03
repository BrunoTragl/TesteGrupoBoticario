using System.ComponentModel.DataAnnotations;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "The field user is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "The field password is required")]
        public string Password { get; set; }
    }
}
