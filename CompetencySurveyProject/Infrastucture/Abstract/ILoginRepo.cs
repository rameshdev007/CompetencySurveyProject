using CompetencySurveyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencySurveyProject.Infrastucture.Abstract
{
    public interface ILoginRepo
    {
        LoginModel ValidateUserLogin(string userId);
    }
}
