using System;

namespace CompetencyAssessment.Models
{
    public class LocationDetailsModel
    {
        public int LocationId { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}