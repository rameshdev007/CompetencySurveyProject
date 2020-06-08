using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompetencySurveyProject.Models
{
    public partial class LoginModel
    {
        [DisplayName("User ID")]
        [Required(ErrorMessage ="Please enter User ID.")]
        public string UserId { get; set; }
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }
        public int RoleId { get; set; }
        public string UserFullName { get; set; }
    }
}
