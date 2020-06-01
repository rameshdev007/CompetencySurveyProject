using CompetencyAssessment.Models;
using CompetencySurveyProject.Infrastucture.Abstract;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class UserRegistration : IUserRegistration
    {
        private string msg;

        public string RegisterUser(UserDetails userDetails)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("RegisterUser", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                command.Parameters.AddWithValue("@UserId", userDetails.UserId);
                command.Parameters.AddWithValue("@EmpId", userDetails.EmployeeId);
                command.Parameters.AddWithValue("@FullName", userDetails.FullName);
                command.Parameters.AddWithValue("@Roleid", userDetails.RoleId);
                command.Parameters.AddWithValue("@LocationId", userDetails.LocationId);
                command.Parameters.AddWithValue("@EmailId", userDetails.EmailId);
                command.Parameters.AddWithValue("@MobileNumber", userDetails.MobileNumber);
                command.Parameters.AddWithValue("@Password", userDetails.Password);

                connection.Open();
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                msg = (num > 0) ? "success" : "failed";
            }
            catch (Exception ex)
            {
                msg = "Exception while saving the record: " + ex.Message;
            }
            return msg;
        }
    }
}