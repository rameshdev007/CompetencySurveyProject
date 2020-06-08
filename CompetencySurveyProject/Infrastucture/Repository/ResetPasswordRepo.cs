using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CompetencySurveyProject.Infrastucture.Abstract;
using System.Web;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class ResetPasswordRepo : IResetPasswordRepo
    {
        public string UpdateuserOTP(string UserId, int OTP)
        {
            string msg;
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("[dbo].[UpdateUserOTP]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                command.Parameters.AddWithValue("@UserId", UserId);
                command.Parameters.AddWithValue("@OTP", OTP);

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

        public string UpdateUserPassword(string OTP, string Password)
        {
            string msg;
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("[dbo].[UpdateUserPasswordWithOTP]", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                command.Parameters.AddWithValue("@OTP", int.Parse(OTP));
                command.Parameters.AddWithValue("@Password", Password);

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