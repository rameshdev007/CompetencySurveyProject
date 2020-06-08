using CompetencySurveyProject.Models;
using CompetencySurveyProject.Infrastucture.Abstract;
using CompetencySurveyProject.Infrastucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencySurveyProject.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LoginModel loginModel)
        {
            ILoginRepo getUserRecord = new LoginRepo();
            LoginModel userRecord = getUserRecord.ValidateUserLogin(loginModel.UserId);


            bool isUserPasswordValidated = ValidatePassword(userRecord, loginModel.Password);

            if (!isUserPasswordValidated)
            {
                loginModel.LoginErrorMessage = "Incorrect User ID or Password.";
                return View("Login", loginModel);
            }

            if (IsAdminUser(userRecord))
            {
                Session["userID"] = loginModel.UserId;
                Session["userFullName"] = userRecord.UserFullName;
                return RedirectToAction("RegisterUser", "RegisterUser");
            }

            Session["userID"] = loginModel.UserId;
            Session["userFullName"] = userRecord.UserFullName;
            return RedirectToAction("Index", "UserDashBoard");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

        private bool ValidatePassword(LoginModel userRecord, string passWord)
        {
            bool validUserLogin = userRecord.Password == passWord ? true : false;
            return validUserLogin;
        }

        private bool IsAdminUser(LoginModel userRecord)
        {
            return userRecord.RoleId == 10;
        }
    }
}