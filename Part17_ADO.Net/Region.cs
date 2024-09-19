using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part17_ADO.Net
{
    public class Region
    {
        private readonly IConfiguration _configuration;
        public Region(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void All()
        {
            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            using SqlCommand sqlCommand = new("SELECT * FROM [regions]", sqlConnection);

            sqlConnection.Open();

            using var reader = sqlCommand.ExecuteReader();
            {
                if (!reader.HasRows) { return; }
                while (reader.Read())
                {
                    Console.WriteLine($"Region Id: {reader["region_id"]} -- Region Name: {reader["region_name"]}");
                }
            }

            sqlConnection.Close();
        }

        //test for Sql injection
        public void GetLogins()
        {
            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            using SqlCommand sqlCommand = new("SELECT * FROM [logins] WHERE userlogin = '" + "admin'; truncate table logins;", sqlConnection);

            sqlConnection.Open();

            using var reader = sqlCommand.ExecuteReader();
            {
                if (!reader.HasRows) { return; }
                while (reader.Read())
                {
                    Console.WriteLine($"User: {reader["userlogin"]} -- Pass: {reader["pwd"]}");
                }
            }

            sqlConnection.Close();
        }

        public void Add(string name)
        {
            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            using SqlCommand sqlCommand = new("INSERT INTO [regions](region_name) VALUES(@Name)", sqlConnection);

            sqlConnection.Open();

            sqlCommand.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar)).Value = name;

            var rowEffect = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Total of Added effect records  is {rowEffect}");
            sqlConnection.Close();
        }

        public void Update(int id, string updateValue)
        {
            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            using SqlCommand sqlCommand = new("UPDATE [regions] SET  region_name = @Name WHERE region_id = @Id", sqlConnection);

            sqlConnection.Open();

            sqlCommand.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar)).Value = updateValue;
            sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int)).Value = id;

            var rowEffect = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Total of updated effect records  is {rowEffect}");
            sqlConnection.Close();
        }

        public void Delete(int id)
        {
            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            using SqlCommand sqlCommand = new("DELETE FROM [regions] WHERE region_id = @Id", sqlConnection);

            sqlConnection.Open();

            sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int)).Value = id;

            var rowEffect = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Total of deleted effect records  is {rowEffect}");
            sqlConnection.Close();
        }

        // include update and add and delete row in one transaction
        public void CommitTransaction(int idToUpdate, int idToDelete, string name, string newValueName)
        {
            Console.WriteLine("Begin Commit Transaction");

            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            sqlConnection.Open();

            var transaction = sqlConnection.BeginTransaction();

            DeleteInTraction(idToDelete, sqlConnection, transaction);
            AddinTransaction(name, sqlConnection, transaction);
            UpdateInTransaction(idToUpdate, newValueName, sqlConnection, transaction);

            transaction.Commit();

            sqlConnection.Close();

            Console.WriteLine("End Commit Transaction");
        }

        public void RollbackTransaction(int idToUpdate, int idToDelete, string name, string newValueName)
        {
            Console.WriteLine("Begin Rollback Transaction");

            using SqlConnection sqlConnection = FactoryConnection.CreateConnection(_configuration);

            sqlConnection.Open();

            var transaction = sqlConnection.BeginTransaction();

            DeleteInTraction(idToDelete, sqlConnection, transaction);
            AddinTransaction(name, sqlConnection, transaction);
            UpdateInTransaction(idToUpdate, newValueName, sqlConnection, transaction);

            transaction.Rollback();

            sqlConnection.Close();
            Console.WriteLine("End Rollback Transaction");

        }

        private static void UpdateInTransaction(int id, string newValueName, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            using SqlCommand sqlCommand = new("UPDATE [regions] SET  region_name = @Name WHERE region_id = @Id", sqlConnection, transaction);

            sqlCommand.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar)).Value = newValueName;
            sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int)).Value = id;

            var rowEffect = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Total of updated effect records  is {rowEffect}");
            return ;
        }

        private static void AddinTransaction(string name, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            using SqlCommand sqlCommand = new("INSERT INTO [regions](region_name) VALUES(@Name)", sqlConnection, transaction);

            sqlCommand.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar)).Value = name;

            var rowEffect = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Total of Added effect records  is {rowEffect}");
            return;
        }

        private static void DeleteInTraction(int id, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            using SqlCommand sqlCommand = new("DELETE FROM [regions] WHERE region_id = @Id", sqlConnection, transaction);

            sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int)).Value = id;

            var rowEffect = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"Total of deleted effect records  is {rowEffect}");

            return;
        }
    }
}
