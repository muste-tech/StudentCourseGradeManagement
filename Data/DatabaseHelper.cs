using MySql.Data.MySqlClient;
using System;
namespace Mustakim
{
   public class DatabaseHelper
    {
        private readonly string _connectionString;
        public DatabaseHelper(string server = "localhost", string database = "companydatabase", string username = "root", string password = "585502")
        {
            _connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            TestConnection();
        }

        private void TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                throw;
            }   
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}

