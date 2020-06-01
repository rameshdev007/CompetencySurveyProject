using CompetencySurveyProject.Infrastucture.Repository;
using System;

namespace CompetencyAssessment.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string EmployeeId { get; set; }

        public string FullName { get; set; }

        public int RoleId { get; set; }

        public int LocationId { get; set; }

        public string EmailId { get; set; }

        public string MobileNumber { get; set; }

        public string Password { get; set; }

        public DateTime LastLoggedOnDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}