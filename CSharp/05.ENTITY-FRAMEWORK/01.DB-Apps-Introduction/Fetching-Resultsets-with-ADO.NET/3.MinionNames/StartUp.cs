namespace _3.MinionNames
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
                int id = int.Parse(Console.ReadLine());

                try
                {
                    //Define villain query
                    string query = @"SELECT [Name]
                                 FROM Villains
                                 WHERE Id = @Id";

                    //Define villain command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        string villainName = (string)command.ExecuteScalar();

                        if (villainName == null)
                        {
                            Console.WriteLine($"No villain with ID {id} exists in the database.");
                            return;
                        }

                        Console.WriteLine($"Villain: {villainName}");
                    }

                    //Define minions query
                    query = @"SELECT m.[Name],
	                      m.Age,
	                      ROW_NUMBER() OVER(PARTITION BY mv.VillainId ORDER BY m.[Name] ASC) AS Number
                          FROM Minions AS m
                          JOIN MinionsVillains AS mv ON mv.MinionId = m.Id
                          WHERE mv.VillainId = @Id";

                    //Define minions command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        //Execute reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }

                            while (reader.Read())
                            {
                                long number = (long)reader["Number"];
                                string minionName = (string)reader["Name"];
                                int minionAge = (int)reader["Age"];

                                Console.WriteLine($"{number}. {minionName} {minionAge}");
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
