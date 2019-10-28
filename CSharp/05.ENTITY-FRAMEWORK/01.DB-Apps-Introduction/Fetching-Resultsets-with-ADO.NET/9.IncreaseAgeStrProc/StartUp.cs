namespace _9.IncreaseAgeStrProc
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
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    //Execute procedure
                    ExecGetolderProc(minionId, connection);

                    //Print output
                    PrintOutput(minionId, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintOutput(int minionId, SqlConnection connection)
        {
            string query = @"SELECT Name,
                                    Age 
                             FROM Minions 
                             WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", minionId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string minonName = (string)reader["Name"];
                        int minionAge = (int)reader["Age"];

                        Console.WriteLine($"{minonName} - {minionAge} years old");
                    } 
                }
            }
        }

        private static void ExecGetolderProc(int minionId, SqlConnection connection)
        {
            string query = "EXEC usp_GetOlder @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", minionId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
