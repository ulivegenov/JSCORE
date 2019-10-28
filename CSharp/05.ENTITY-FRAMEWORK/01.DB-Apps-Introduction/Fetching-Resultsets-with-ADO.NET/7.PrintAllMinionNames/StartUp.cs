namespace _7.PrintAllMinionNames
{
    using _1._Initial_Setup;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            List<string> minionsNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    // Get minions names
                    GetMinionsNames(minionsNames, connection);

                    //Print output
                    PrintOutput(minionsNames);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintOutput(List<string> minionsNames)
        {
            for (int i = 0; i < minionsNames.Count/2; i++)
            {
                Console.WriteLine(minionsNames[i]);
                Console.WriteLine(minionsNames[minionsNames.Count - 1 - i]);
            }

            if (minionsNames.Count % 2 != 0)
            {
                Console.WriteLine(minionsNames[minionsNames.Count/2]);
            }
        }

        private static void GetMinionsNames(List<string> minionsNames, SqlConnection connection)
        {
            string query = @"SELECT [Name]
                             FROM Minions";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string currentName = (string)reader["Name"];
                        minionsNames.Add(currentName);
                    }
                }
            }
        }
    }
}
