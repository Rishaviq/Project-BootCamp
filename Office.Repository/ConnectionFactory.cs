﻿using Microsoft.Data.SqlClient;

namespace Office.Repositories
{
    public static class ConnectionFactory
    {
        private static string? _connectionString;

        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<SqlConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
