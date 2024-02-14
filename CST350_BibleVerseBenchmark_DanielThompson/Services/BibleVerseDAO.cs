using CST350_BibleVerseBenchmark_DanielThompson.Models;
using Microsoft.Data.SqlClient;

namespace CST350_BibleVerseBenchmark_DanielThompson.Services
{
    public class BibleVerseDAO
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bible;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<BibleModel> Search(string searchTerm, int searchOption)
        {
            List<BibleModel> searchResults = new List<BibleModel>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string searchQuery;

                if(searchOption == 1)
                    searchQuery = "SELECT t_asv.id, key_english.n AS EnglishName, t_asv.c, t_asv.v,t_asv.t " +
                    "FROM dbo.t_asv " +
                    "JOIN dbo.key_english ON t_asv.b = key_english.b " +
                    "WHERE t_asv.t LIKE '%' + @searchTerm + '%' AND dbo.t_asv.b < 40;";
                else if(searchOption == 2)
                    searchQuery = "SELECT t_asv.id, key_english.n AS EnglishName, t_asv.c, t_asv.v,t_asv.t " +
                    "FROM dbo.t_asv " +
                    "JOIN dbo.key_english ON t_asv.b = key_english.b " +
                    "WHERE t_asv.t LIKE '%' + @searchTerm + '%' AND dbo.t_asv.b > 40;";
                else
                    searchQuery = "SELECT t_asv.id, key_english.n AS EnglishName, t_asv.c, t_asv.v,t_asv.t " +
                    "FROM dbo.t_asv " +
                    "JOIN dbo.key_english ON t_asv.b = key_english.b " +
                    "WHERE t_asv.t LIKE '%' + @searchTerm + '%';";



                using (SqlCommand command = new SqlCommand(searchQuery, connection)) 
                {
                    command.Parameters.AddWithValue("@searchTerm", searchTerm);

                    using(SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while(reader.Read())
                        {
                            BibleModel newModel = new BibleModel
                            {
                                ID = reader.GetInt32(0),
                                Book = reader.GetString(1),
                                Chapter = reader.GetInt32(2),
                                Verse = reader.GetInt32(3),
                                Text = reader.GetString(4)
                            };

                            searchResults.Add(newModel);
                        }
                    }
                }
            }

            return searchResults;
        }
    }
}
