using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using DesaCerdasScheduler.Models;

namespace DesaCerdasScheduler.Repositories
{

    public class DistrictRepository
    {
        static string ConnectionStrings = ConfigurationManager.ConnectionStrings["DesaCerdas_MasterEntities"].ToString();
        public static List<DistrictModel> GetAllDistrict()
        {
            List<DistrictModel> dist = new List<DistrictModel>();
            SqlConnection sqlconnection;
            try
            {
                sqlconnection = new SqlConnection(ConnectionStrings);
                sqlconnection.Open();
                string insertQuery = "Select ID, RegionID, Longitude, Latitude from District where IsDeleted = 0";
                SqlCommand insertcommand = new SqlCommand(insertQuery, sqlconnection);
                SqlDataReader datareader = insertcommand.ExecuteReader();
                while (datareader.Read())
                {
                    var tempDist = new DistrictModel();
                    tempDist.ID = datareader.GetValue(0).ToString();
                    tempDist.RegionID = datareader.GetValue(1).ToString();
                    tempDist.Longitude = datareader.GetValue(2).ToString();
                    tempDist.Latitude = datareader.GetValue(3).ToString();
                    dist.Add(tempDist);
                }
                datareader.Close();
                sqlconnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dist;
        }
    }
}
