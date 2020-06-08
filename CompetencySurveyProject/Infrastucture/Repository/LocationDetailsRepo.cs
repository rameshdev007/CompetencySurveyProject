using CompetencySurveyProject.Infrastucture.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CompetencySurveyProject.Models;

namespace CompetencySurveyProject.Infrastucture.Repository
{
    public class LocationDetailsRepo : ILocationDetails
    {

        public List<LocationDetailsModel> GetLocationsList()
        {
            List<LocationDetailsModel> list = new List<LocationDetailsModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CompetencyAssessmentDB"]);
            SqlCommand command = new SqlCommand("GetLocationList", connection)
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
                    LocationDetailsModel locationRecord = new LocationDetailsModel();
                    locationRecord.LocationId = (int)reader.GetValue(0);
                    locationRecord.Location = reader.GetValue(1).ToString();
                    list.Add(locationRecord);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not get the location details");
            }
            return list;
        }
    }
}