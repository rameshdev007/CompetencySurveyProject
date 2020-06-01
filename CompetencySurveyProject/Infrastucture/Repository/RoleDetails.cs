using CompetencyAssessment.Models;
using CompetencySurveyProject.Infrastucture.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class RoleDetails : IRoleDetails
    {
        public List<RoleDetailsModel> GetRolesList()
        {
            List<RoleDetailsModel> list = new List<RoleDetailsModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("GetRolesList", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RoleDetailsModel roleRecord = new RoleDetailsModel
                    {
                        RoleId = (int)reader.GetValue(0),
                        RoleName = reader.GetValue(1).ToString()
                    };
                    list.Add(roleRecord);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not get the role details");
            }
            return list;
        }
    }
}