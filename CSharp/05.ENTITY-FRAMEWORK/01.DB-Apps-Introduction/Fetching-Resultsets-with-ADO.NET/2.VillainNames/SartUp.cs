namespace _2.VillainNames
{
    using _1._Initial_Setup;
    using System;
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main()
        {
            //Define connection
            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                //Define query
                string query = @"SELECT v.[Name],
	                             COUNT(mv.MinionId) AS MinionsCount
                                 FROM Villains AS v
                                 LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id 
                                 GROUP BY v.[Name]
                                 HAVING COUNT(mv.MinionId) > 3
                                 ORDER BY MinionsCount DESC";
                try
                {
                    //Define command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //Execute reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = (string)reader["Name"];
                                int minionsCount = (int)reader["MinionsCount"];

                                Console.WriteLine($"{name} - {minionsCount}");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }  
            }
        }
    }
}
