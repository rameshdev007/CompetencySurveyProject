using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetencyAssessment.Models
{
    public class RoleDetailsModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}