namespace _5.ChangeTownNamesCasing
{
    using _1._Initial_Setup;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            //Read input data
            string countryName = Console.ReadLine();

            // Define conection
            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    //Check if country exist
                    int? countryCode = GetCountryId(countryName, connection);

                    if (countryCode == null)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    //Change town names casing
                    int rowsAffected = ChangeCasing(countryCode, connection);

                    //Print Result
                    PrintOutput(rowsAffected, countryCode, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintOutput(int rowsAffected, int? countryCode, SqlConnection connection)
        {
            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                string query = @"SELECT [Name]
                                 FROM Towns
                                 WHERE CountryCode = @countryCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@countryCode", countryCode);

                    HashSet<string> townsNames = new HashSet<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string townName = (string)reader["Name"];
                            townsNames.Add(townName);
                        }
                    }

                    Console.WriteLine($"[{string.Join(", ", townsNames)}]");
                }
            }
        }

        private static int ChangeCasing(int? countryCode, SqlConnection connection)
        {
            string query = @"UPDATE Towns
                             SET Name = UPPER(Name)
                             WHERE CountryCode = @countryCode";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@countryCode", countryCode);

                return command.ExecuteNonQuery();
            }
        }

        private static int? GetCountryId(string countryName, SqlConnection connection)
        {
            string query = @"SELECT Id 
                             FROM Countries
                             WHERE [Name] = @countryName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                return (int?)command.ExecuteScalar();
            }
        }
    }
}
