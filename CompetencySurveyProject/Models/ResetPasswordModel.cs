using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetencySurveyProject.Models
{
    public class ResetPasswordModel
    {
        public string UserId;

        [Required(ErrorMessage ="Please enter the OTP you received in Email", AllowEmptyStrings = false)]
        public string ResetCode { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter new password", AllowEmptyStrings = false)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter new password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="Confirm password should match New Password")]
        public string ConfirmPassword { get; set; }
    }
}