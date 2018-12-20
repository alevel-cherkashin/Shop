using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Shop.Data.Repozitory
{
    public class ClientRepozitory: IClientRepository
    {
        private const string connectionString = @"Data Source = CORSAR-PC\SQLEXPRESS;Initial Catalog = Shop; Integrated Security = True";

        public int Add(Client client)
        {
            string sqlExpression = "Client_Insert";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParamert = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = client.Name,
                    SqlDbType = SqlDbType.NVarChar
                };

                command.Parameters.Add(nameParamert);

                SqlDataReader reader = command.ExecuteReader();

                int result = reader.GetInt32(0);

                return result;
            }
        }

        public void Update(Client client)
        {
            string sqlExpression = "Client_Update";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParamert = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = client.Name,
                     SqlDbType = SqlDbType.NVarChar
                };

                command.Parameters.Add(nameParamert);

                SqlParameter idParamert = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = client.Id,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(idParamert);
                var result = command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "Client_Delete";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParamert = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(idParamert);
                var result = command.ExecuteNonQuery();
            }
        }

        public Client GetDeteils(int id)
        {
            string sqlExpression = $"SELECT * FROM Client WHERE Id={id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                Client client = new Client();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        client.Name = reader.GetString(1);
                        client.IsDeleted = reader.GetBoolean(2);
                    }
                }
                return client;
            }
        }

        public List<Client> Get()
        {
            string sqlExpression = $"SELECT * FROM Client";

            List<Client> clients = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
             
                var dataTeble = new DataTable();
                dataTeble.Load(reader);

                foreach (DataRow dr in dataTeble.Rows)
                {
                    var client = new Client();

                    client.Id = int.Parse(dr["Id"].ToString());
                    client.Name = dr["Name"].ToString();
                    client.IsDeleted = bool.Parse(dr["IsDelete"].ToString());

                    clients.Add(client);
                }
            }
            return clients;
        }
    }
}
