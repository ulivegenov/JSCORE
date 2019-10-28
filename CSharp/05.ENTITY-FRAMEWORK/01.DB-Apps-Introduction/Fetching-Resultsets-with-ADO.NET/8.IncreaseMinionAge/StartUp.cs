namespace _8.IncreaseMinionAge
{
    using _1._Initial_Setup;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //Read input data
            int[] minionsIds = Console.ReadLine().Split()
                                               .Select(int.Parse)
                                               .ToArray();

            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    //Change casing and increment age
                    UpdateData(minionsIds, connection);

                    //Print output
                    PrintOutput(connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintOutput(SqlConnection connection)
        {
            string query = @"SELECT [Name], 
                                    Age 
                             FROM Minions";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string minionName = (string)reader["Name"];
                        int minionAge = (int)reader["Age"];
                        Console.WriteLine($"{minionName} {minionAge}");
                    }
                }
            }
        }

        private static void UpdateData(int[] minionsIds, SqlConnection connection)
        {
            string query = @"UPDATE Minions
                             SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                             WHERE Id = @Id";

            foreach (var id in minionsIds)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
