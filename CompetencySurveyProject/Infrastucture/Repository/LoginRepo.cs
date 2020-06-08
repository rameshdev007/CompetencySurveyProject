using CompetencySurveyProject.Infrastucture.Abstract;
using CompetencySurveyProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public LoginModel ValidateUserLogin(string userId)
        {
            LoginModel userRecord = new LoginModel();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("GetUserRecord", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader reader;
            command.Parameters.AddWithValue("@UserId", userId);
            try
            {
                connection.Open();
                
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userRecord.UserId = reader.GetValue(1).ToString();
                    userRecord.Password = reader.GetValue(8).ToString();
                    userRecord.EmailId = reader.GetValue(6).ToString();
                    userRecord.RoleId = (int)reader.GetValue(4);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not get the user record");
            }
            return userRecord;
        }
    }
}