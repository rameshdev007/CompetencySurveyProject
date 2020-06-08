using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompetencySurveyProject.Models
{
    public class ResetPasswordModel
    {
        public string UserId;

        [Required(ErrorMessage ="Please enter the OTP you received in Email", AllowEmptyStrings = false)]
        [DisplayName("OTP")]
        public string ResetCode { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Please enter new password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter confirm password", AllowEmptyStrings = false)]
        [DisplayName("Confirm Password")]
        [Compare("NewPassword", ErrorMessage ="Confirm password should match New Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter current password", AllowEmptyStrings = false)]
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}