namespace _4.AddMinion
{
    using _1._Initial_Setup;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string DEFAULT_EVILNESS_FACTOR = "evil";
        public static void Main()
        {
            //Read input data
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            string villainName = villainInfo[1];

            //Define connection
            using (SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME)))
            {
                connection.Open();

                try
                {
                    //Check if Town exists
                    int? townId = GetTownId(townName, connection);

                    if (townId == null)
                    {
                        AddTown(townName, connection);

                        townId = GetTownId(townName, connection);
                    }

                    //Add minion
                    AddMinion(minionName, minionAge, townId, connection);

                    //Check if villain exist
                    int? villainId = GetVillainId(villainName, connection);

                    if (villainId == null)
                    {
                        AddVillain(villainName, DEFAULT_EVILNESS_FACTOR, connection);

                        villainId = GetVillainId(villainName, connection);
                    }

                    //Set the new minion to be a servant of the villain (Add record to mapping table)
                    int minionId = GetMinionId(minionName, connection);

                    AddMinionToVillain(minionName, minionId, villainName, villainId, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void AddMinionToVillain(string minionName, int minionId, string villainName, int? villainId, SqlConnection connection)
        {
            string query = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                             VALUES (@minionId, @villainId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@minionId", minionId);
                command.Parameters.AddWithValue("@villainId", villainId);

                command.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int GetMinionId(string minionName, SqlConnection connection)
        {
            string query = @"SELECT Id
                             FROM Minions
                             WHERE [Name] = @minionName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@minionName", minionName);

                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(string villainName, string dEFAULT_EVILNESS_FACTOR, SqlConnection connection)
        {
            int evilnessFactorId = GetEvillnesFactorId(dEFAULT_EVILNESS_FACTOR, connection);

            string query = @"INSERT INTO Villains([Name], EvilnessFactorId)
                             VALUES (@villainName, @evillnessFactorId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.Parameters.AddWithValue("@evillnessFactorId", evilnessFactorId);

                command.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static int GetEvillnesFactorId(string evilnessFactorName, SqlConnection connection)
        {
            string query = @"SELECT Id
                             FROM EvilnessFactors
                             WHERE [Name] = @evilnessFactorName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@evilnessFactorName", evilnessFactorName);

                return (int)command.ExecuteScalar();
            }
        }

        private static int? GetVillainId(string villainName, SqlConnection connection)
        {
            string query = @"SELECT Id
                            FROM Villains
                            WHERE [Name] = @villainName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(string minionName, int minionAge, int? townId, SqlConnection connection)
        {
            string query = @"INSERT INTO Minions([Name], Age, TownId)
                             VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static void AddTown(string townName, SqlConnection connection)
        {
            string query = @"INSERT INTO Towns([Name])
                             VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);

                command.ExecuteNonQuery();

                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }

        private static int? GetTownId(string townName, SqlConnection connection)
        {
            string query = @"SELECT Id
                            FROM Towns
                            WHERE[Name] = @townName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);

                return (int?)command.ExecuteScalar();
            }
        }
    }
}
