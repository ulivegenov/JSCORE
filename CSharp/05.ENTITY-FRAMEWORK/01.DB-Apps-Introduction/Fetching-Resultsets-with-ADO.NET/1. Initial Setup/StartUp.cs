namespace _1._Initial_Setup
{
    using System;
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main()
        {
            //Define connection
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnnectionString, "master"));

            //Creating database
            using (connection)
            {
                connection.Open();

                string createDatabaseStatement = @"CREATE DATABASE MinionsDB";

                try
                {
                    ExecuteNonQuery(connection, createDatabaseStatement);

                    Console.WriteLine("Database created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error, creating database!");
                    Console.WriteLine(e.Message);

                    return;
                }
                
            }

            //Redefine connection
            connection = new SqlConnection(String.Format(Configuration.ConnnectionString, Configuration.DB_NAME));

            // Creating tables and inserting data
            using (connection)
            {
                connection.Open();

                //Creating tabels queries
                string[] createTablesStatements =
                {
                    "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",

                    "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                    
                    "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                    
                    "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                    
                    "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), " +
                    "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                    
                    "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id)," +
                    "VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
                };

                // Inserting data queries
                string[] insertStatements =
                {
                    "INSERT INTO Countries ([Name]) " +
                    "VALUES('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",

                    "INSERT INTO Towns([Name], CountryCode) " +
                    "VALUES('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1)," +
                    "('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",

                    "INSERT INTO Minions(Name, Age, TownId) " +
                    "VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2)," +
                    "('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",

                    "INSERT INTO EvilnessFactors(Name) VALUES('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",

                    "INSERT INTO Villains(Name, EvilnessFactorId) " +
                    "VALUES('Gru', 2),('Victor', 1),('Jilly', 3),('Miro', 4),('Rosen', 5),('Dimityr', 1),('Dobromir', 2)",

                    "INSERT INTO MinionsVillains(MinionId, VillainId) " +
                    "VALUES(4, 2),(1, 1),(5, 7),(3, 5),(2, 6),(11, 5),(8, 4),(9, 7),(7, 1),(1, 3),(7, 3),(5, 3),(4, 3),(1, 2),(2, 1),(2, 7)"
                };

                int affectedRows = 0;

                try
                {
                    //Createing tables
                    foreach (string createStatement in createTablesStatements)
                    {
                        ExecuteNonQuery(connection, createStatement);
                    }

                    Console.WriteLine("Tables created successfully!");

                    //Insert data
                    foreach (string insertStatement in insertStatements)
                    {
                       affectedRows += ExecuteNonQuery(connection, insertStatement);
                    }

                    Console.WriteLine("Data inserted successfuly!");
                    Console.WriteLine($"{affectedRows} rows affected!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error processing your query!");
                    Console.WriteLine(e.Message);
                }
            }
        }

        //Method that execute a non query command
        private static int ExecuteNonQuery(SqlConnection connection, string commandText)
        {
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                int affectedRows = command.ExecuteNonQuery();

                return affectedRows;
            }
        }
    }
}
