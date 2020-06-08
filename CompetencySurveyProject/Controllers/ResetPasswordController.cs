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
    public class ResetPasswordController : Controller
    {

        // GET: ChangePassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userId)
        {
            string message;
            ILoginRepo getUserRecord = new LoginRepo();
            LoginModel userRecord = getUserRecord.ValidateUserLogin(userId);

            // Verify user ID
            if (userRecord.UserId != null)
            {
                IResetPasswordRepo resetPasswordRepo = new ResetPasswordRepo();

                // Generate OTP
                Random random = new Random();
                int OTP = random.Next(100000, 999999);

                // Store the OTP in DB
                string dbmsg = resetPasswordRepo.UpdateuserOTP(userRecord.UserId, OTP);

                // Send OTP in mail
                if (dbmsg == "success")
                {
                    NotifyUser.SendOTPToUser(userRecord.EmailId, OTP.ToString());
                    message = "OTP sent to your Email";
                    ViewBag.Message = message;
                    //return View();
                    return RedirectToAction("ResetPassword", "ResetPassword");
                }
                else
                {
                    message = "OTP was not sent to the user";
                    ViewBag.Message = message;
                    return View();
                }
            }
            else
            {
                message = "User not found";
                ViewBag.Message = message;
                return View();
            }
        }

        
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            IResetPasswordRepo resetPasswordRepo = new ResetPasswordRepo();

            // Store the Password in DB
            string dbmsg = resetPasswordRepo.UpdateUserPasswordWithOTP(resetPassword.ResetCode, resetPassword.NewPassword);

            // Send OTP in mail
            if (dbmsg == "success")
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.Message = "Password reset un-successful";
                return View();
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ResetPasswordModel resetPasswordModel)
        {
            IResetPasswordRepo resetPasswordRepo = new ResetPasswordRepo();

            // Update the Password in DB
            string userId = (string)Session["userId"];
            string dbmsg = resetPasswordRepo.UpdateUserPassword(userId, resetPasswordModel.CurrentPassword,resetPasswordModel.NewPassword);
            
            if (dbmsg == "success")
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.Message = "Password reset un-successful";
                return View();
            }
        }
    }
}