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
                        landscape.Functions = reader["functions"] is DBNull ? (string)null : (string)reader["functions"];
                        landscape.Approach = reader["approach"] is DBNull ? (string)null : (string)reader["approach"];
                        landscape.OrganizationType = reader["organization_type"] is DBNull ? (string)null : (string)reader["organization_type"];
                        landscape.OrganizationType2 = reader["organization_type_2"] is DBNull ? (string)null : (string)reader["organization_type_2"];
                        landscape.AreaOfFocus = reader["area_of_focus"] is DBNull ? (string)null : (string)reader["area_of_focus"];
                        landscape.Beneficiary = reader["beneficiary"] is DBNull ? (string)null : (string)reader["beneficiary"];
                        landscape.Beneficiary2 = reader["beneficiary_2nd"] is DBNull ? (string)null : (string)reader["beneficiary_2nd"];
                        landscape.BeneficiaryPopNum = reader["beneficiary_pop_num"] is DBNull ? (string)null : (string)reader["beneficiary_pop_num"];
                        landscape.Geography = reader["geography"] is DBNull ? (string)null : (string)reader["geography"];
                        landscape.Address = reader["address"] is DBNull ? (string)null : (string)reader["address"];
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
