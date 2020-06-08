using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetencySurveyProject.Models
{
    public class RoleDetailsModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}