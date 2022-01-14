using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;
using Dapper.Transaction;

namespace MyDapper.Methods
{
    public class Utility
    {
        public static void Async()
        {
            My.Write("async start");
            AsyncMethod();
            My.Write("async finsih");
        }
        private static async void AsyncMethod()
        {
            string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var connection = My.ConnectionFactory())
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { CustomerName = "Mark" }).ConfigureAwait(false);
                My.Write("execute async :" + affectedRows);

                var customers = await connection.QueryAsync<Customer>("Select * FROM CUSTOMERS WHERE CustomerName = 'Mark'").ConfigureAwait(false);
                My.Write("query async :" + customers.Count());
            }
        }

        public static void Buffered()
        {
            string sql = "SELECT * FROM Customers;";

            using (var connection = My.ConnectionFactory())
            {
                //buffered Default: True
                var customers = connection.Query<Customer>(sql, buffered: false).ToList();
                var tmp = customers.Take(10);
                My.Write("query async :" + tmp.Count());
            }
        }

        public static void Transaction()
        {
            string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var connection = My.ConnectionFactory())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = connection.Execute(sql, new { CustomerName = "Mark" }, transaction: transaction);
                        My.Write("transaction insert:" + affectedRows);
                        throw new Exception("xxx");
                        transaction.Commit();
                        My.Write("transaction commit");
                    }
                    catch (Exception ex)
                    {
                        My.Write("transaction exception:" + ex.Message);
                        transaction.Rollback();
                        My.Write("transaction rollback");
                    }
                }
            }
        }

        /// <summary>
        /// using System.Transactions;
        /// </summary>
        public static void TransactionScope()
        {
            string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var transaction = new TransactionScope())
            {
                try
                {
                    using (var connection = My.ConnectionFactory())
                    {
                        //connection.Open();

                        var affectedRows = connection.Execute(sql, new { CustomerName = "Mark" });
                        My.Write("TransactionScope insert:" + affectedRows);
                        throw new Exception("xxx");
                    }

                    transaction.Complete();
                    My.Write("TransactionScope complete");
                }
                catch (Exception ex)
                {
                    My.Write("transactionScope exception:" + ex.Message);
                }
            }
        }

        /// <summary>
        /// using Dapper.Transaction;
        /// </summary>
        public static void TransactionDapper()
        {
            string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var connection = My.ConnectionFactory())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Dapper
                        var affectedRows1 = connection.Execute(sql, new { CustomerName = "Mark" }, transaction: transaction);

                        // Dapper Transaction
                        // 对IDbTransaction进行了拓展,从transaction可以获取到connection
                        var affectedRows2 = transaction.Execute(sql, new { CustomerName = "Mark" });

                        throw new Exception("xxx");

                        transaction.Commit();
                        My.Write("dapper transaction commit");
                    }
                    catch (Exception ex)
                    {
                        My.Write("dapper transaction exception:" + ex.Message);
                        transaction.Rollback();
                        My.Write("dapper transaction rollback");
                    }

                }
            }
        }
    }
}
