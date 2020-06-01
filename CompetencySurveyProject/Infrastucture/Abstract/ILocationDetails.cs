using CompetencyAssessment.Models;
using System.Collections.Generic;

namespace CompetencySurveyProject.Infrastucture.Abstract
{
    public interface ILocationDetails
    {
        List<LocationDetailsModel> GetLocationsList();
    }
}
