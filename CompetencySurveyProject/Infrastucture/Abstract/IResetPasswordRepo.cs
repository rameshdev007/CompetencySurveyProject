using CompetencySurveyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencySurveyProject.Infrastucture.Abstract
{
    interface IResetPasswordRepo
    {
        string UpdateuserOTP(string UserId, int OTP);
        string UpdateUserPassword(string OTP, string Password);
    }
}