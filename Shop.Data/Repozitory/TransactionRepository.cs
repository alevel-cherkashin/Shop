using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.DataModels;

namespace Shop.Data.Repozitory
{
    public class TransactionRepository : ITransactionRepository
    {
        private const string connectionString = @"Data Source = CORSAR-PC\SQLEXPRESS;Initial Catalog = Shop; Integrated Security = True";

        public int Add(Transaction transaction)
        {
            string sqlExpression = "Transaction_Insert";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter amountParamert = new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = transaction.Amount,
                    SqlDbType = SqlDbType.Float
                };
                command.Parameters.Add(amountParamert);

                SqlParameter dataParamert = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = transaction.Date,
                    SqlDbType = SqlDbType.DateTime
                };
                command.Parameters.Add(dataParamert);

                SqlParameter isDeletedParamert = new SqlParameter
                {
                    ParameterName = "@IsDeleted",
                    Value = transaction.IsDeleted,
                    SqlDbType = SqlDbType.Bit
                };
                command.Parameters.Add(isDeletedParamert);

                SqlParameter clientIdParamert = new SqlParameter
                {
                    ParameterName = "@ClientId",
                    Value = transaction.Client.Id,
                    SqlDbType = SqlDbType.Bit
                };
                command.Parameters.Add(clientIdParamert);

                SqlDataReader reader = command.ExecuteReader();

                int result = reader.GetInt32(0);
                return result;
            }
        }

        public void Update(Transaction transaction)
        {
            string sqlExpression = "Transaction_Update";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter amountParamert = new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = transaction.Amount,
                    SqlDbType = SqlDbType.Float
                };
                command.Parameters.Add(amountParamert);

                SqlParameter dataParamert = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = transaction.Date,
                    SqlDbType = SqlDbType.DateTime
                };
                command.Parameters.Add(dataParamert);

                SqlParameter clientIdParamert = new SqlParameter
                {
                    ParameterName = "@ClientId",
                    Value = transaction.Client.Id,
                    SqlDbType = SqlDbType.Bit
                };
                command.Parameters.Add(clientIdParamert);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "Transaction_Delete";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

               
                SqlParameter IdParamert = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Bit
                };
                command.Parameters.Add(IdParamert);

                command.ExecuteNonQuery();
            }
        }

        public List<Transaction> Get()
        {
            string sqlExpression = "SELECT * FROM Transaction";
            List<Transaction> transactions = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                var dataTeble = new DataTable();
                dataTeble.Load(reader);

                foreach (DataRow dr in dataTeble.Rows)
                {
                    var tranaction = new Transaction();

                    tranaction.Id = int.Parse(dr["Id"].ToString());
                    tranaction.ClientId = int.Parse(dr["ClientId"].ToString());
                    tranaction.Date = DateTime.Parse(dr["Date"].ToString());
                    tranaction.Amount = float.Parse(dr["Amount"].ToString());
                    tranaction.IsDeleted = bool.Parse(dr["IsDelete"].ToString());

                    transactions.Add(tranaction);
                }
            }
            return transactions;
        }
        
        public Transaction GetDeteils(int id)
        {
            string sqlExpression = $"SELECT * FROM Transaction WHERE Id={id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                Transaction transaction = new Transaction();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        transaction.Id = reader.GetInt32(0);
                        transaction.ClientId = reader.GetInt32(1);
                        transaction.Date = reader.GetDateTime(3);
                        transaction.Amount = reader.GetFloat(4);
                        transaction.IsDeleted = reader.GetBoolean(5);

                    }
                }
                return transaction;
            }
        }

    }
}
