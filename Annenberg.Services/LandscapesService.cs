using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Annenberg.Services.Domains;
using System.Data.SqlClient;

namespace Annenberg.Services
{
    public class LandscapesService : ILandscapesService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AnnenbergConnection"].ConnectionString;

        public List<AnnenbergLandscape> GetAll()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                List<AnnenbergLandscape> landscapes = null;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "AnnenbergLandscapes_getall";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AnnenbergLandscape landscape = new AnnenbergLandscape();
                        landscape.Id = reader.GetInt32(0);
                        landscape.Organization = reader.GetString(1);
                        landscape.Functions = reader.GetString(2);
                        landscape.Approach = reader.GetString(3);
                        landscape.OrganizationType = reader.GetString(4);
                        landscape.OrganizationType2 = reader.GetString(5);
                        landscape.AreaOfFocus = reader.GetString(6);
                        landscape.Beneficiary = reader.GetString(7);
                        landscape.Beneficiary2 = reader.GetString(8);
                        landscape.BeneficiaryPopNum = reader.GetString(9);
                        landscape.Geography = reader.GetString(10);
                        landscape.Address = reader.GetString(11);
                        landscape.DateCreated = reader.GetDateTime(12);
                        landscape.DateModified = reader.GetDateTime(13);
                        if (landscapes == null)
                            landscapes = new List<AnnenbergLandscape>();
                        landscapes.Add(landscape);
                    }
                    return landscapes;
                }
            }
        }

    }
}
