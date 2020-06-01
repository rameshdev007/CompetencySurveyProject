using CompetencyAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencySurveyProject.Infrastucture.Abstract
{
    interface IUserRegistration
    {
        string RegisterUser(UserDetails userDetails);
    }
}
