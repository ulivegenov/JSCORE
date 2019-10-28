namespace _6.RemoveVillain
{
    using _1._Initial_Setup;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            // Read input data
            int villainIdToDelete = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    // Check if villain exists
                    string villainName = GetVillainName(villainIdToDelete, connection);

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                    //Release minions
                    int? releasedMinionsCount = ReleaseMinions(villainIdToDelete, connection);

                    //Delete villain
                    DeleteVillain(villainIdToDelete, releasedMinionsCount, villainName, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }  
            }
        }

        private static void DeleteVillain(int villainIdToDelete, int? releasedMinionsCount, string villainName, SqlConnection connection)
        {
            string query = @"DELETE FROM Villains
                             WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainIdToDelete);

                command.ExecuteNonQuery();
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinionsCount} minions were released.");
            }
        }

        private static int? ReleaseMinions(int villainIdToDelete, SqlConnection connection)
        {
            string query = @"DELETE FROM MinionsVillains 
                             WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainIdToDelete);

                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int villainIdToDelete, SqlConnection connection)
        {
            string query = @"SELECT [Name] 
                             FROM Villains 
                             WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainIdToDelete);

                return (string)command.ExecuteScalar();
            }
        }
    }
}
