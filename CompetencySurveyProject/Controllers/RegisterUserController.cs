using CompetencyAssessment.Models;
using CompetencySurveyProject.Infrastucture.Abstract;
using CompetencySurveyProject.Infrastucture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencySurveyProject.Controllers
{
    public class RegisterUserController : Controller
    {
        readonly IUserRegistration dbObj = new UserRegistration();

        [HttpGet]
        public ActionResult RegisterUser()
        {
            ILocationDetails locationDetails = new LocationDetails();
            List<SelectListItem> locationList = new List<SelectListItem>();
            List<LocationDetailsModel> locationFromDB = locationDetails.GetLocationsList();
            foreach(var l in locationFromDB)
            {
                locationList.Add(new SelectListItem{Text = l.Location, Value = l.LocationId.ToString()});
            }
            ViewData["LocationList"] = locationList;

            IRoleDetails roleDetails = new RoleDetails();
            List<SelectListItem> roleList = new List<SelectListItem>();
            List<RoleDetailsModel> rolesFromDB = roleDetails.GetRolesList();
            foreach (var r in rolesFromDB)
            {
                roleList.Add(new SelectListItem { Text = r.RoleName, Value = r.RoleId.ToString()});
            }
            ViewData["RoleList"] = roleList;

            return View();
        }

        [HttpPost]
        public ActionResult SubmitUserDetails(UserDetails userDetails)
        {
            Random random = new Random();
            userDetails.Password = random.Next(1000, 9999).ToString();
            string msg = dbObj.RegisterUser(userDetails);

            if (msg.Equals("success"))
            {
                NotifyUser.SendEmail(userDetails.FullName, userDetails.EmailId, userDetails.UserId, userDetails.Password);
                return RedirectToAction("RegisterUser");
            }
            else
            {
                return View("FailureMessage");
            }
        }
    }   
}