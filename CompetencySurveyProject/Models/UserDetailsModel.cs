using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompetencySurveyProject.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        [DisplayName("User ID")]
        [Required(ErrorMessage = "This filed is required", AllowEmptyStrings = false)]
        public string UserId { get; set; }

        [DisplayName("Employee ID")]
        [Required(ErrorMessage = "This filed is required", AllowEmptyStrings = false)]
        public string EmployeeId { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "This filed is required", AllowEmptyStrings = false)]
        public string FullName { get; set; }

        [DisplayName("User Role")]
        public int RoleId { get; set; }

        [DisplayName("Location")]
        public int LocationId { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "This filed is required", AllowEmptyStrings = false)]
        public string EmailId { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "This filed is required", AllowEmptyStrings = false)]
        public string MobileNumber { get; set; }

        public string Password { get; set; }

        public DateTime LastLoggedOnDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}