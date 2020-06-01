using CompetencyAssessment.Models;
using System.Collections.Generic;

namespace CompetencySurveyProject.Infrastucture.Abstract
{
    public interface IRoleDetails
    {
        List<RoleDetailsModel> GetRolesList();
    }
}