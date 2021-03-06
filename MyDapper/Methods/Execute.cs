using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MyDapper.Methods
{
    class Execute
    {
        public static void ExecuteINSERT()
        {
            string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

            using (var connection = My.ConnectionFactory())
            {
                var affectedRows = connection.Execute(sql, new { CustomerName = "Mark" });
                My.Write("insert single: " + affectedRows);

                affectedRows = connection.Execute(sql, new[] {
                    new { CustomerName = "Mark" },
                    new { CustomerName = "Mark" },
                    new { CustomerName = "Mark" }
                });
                My.Write("insert many: " + affectedRows);

                var coustomers = new List<Customer>
                {
                    new Customer { CustomerName="Cat"},
                    new Customer { CustomerName="Cat"},
                    new Customer { CustomerName="Cat"},
                };
                affectedRows = connection.Execute(sql, coustomers);
                My.Write("insert entities: " + affectedRows);
            }
        }

        public static void ExecuteUPDATE()
        {
            string sql = "UPDATE Customers SET CustomerName = @CustomerName WHERE CustomerId = @CustomerId;";

            using (var connection = My.ConnectionFactory())
            {
                var affectedRows = connection.Execute(sql, new { CustomerId = 1, CustomerName = "First" });
                My.Write("update single: " + affectedRows);

                affectedRows = connection.Execute(sql, new[] {
                    new { CustomerId = 2, CustomerName = "Second" },
                    new { CustomerId = 3, CustomerName = "Third" } }
                );
                My.Write("update many: " + affectedRows);

                var coustomers = new List<Customer>
                {
                    new Customer {CustomerID=4, CustomerName="Cat1"},
                    new Customer { CustomerID=5,CustomerName="Cat2"},
                    new Customer {CustomerID=6, CustomerName="Cat3"},
                };
                affectedRows = connection.Execute(sql, coustomers);
                My.Write("update entities: " + affectedRows);
            }
        }

        public static void ExecuteDELETE()
        {
            string sql = "delete from customers where customerid in (select max(customerid)customerid from customers) ;";
            string sql2 = "delete from customers where customerid=@customerid";
            string sql3 = "delete from customers where customerid in @customerid3";

            using (var connection = My.ConnectionFactory())
            {
                var affectedRows = connection.Execute(sql);
                My.Write("delete: " + affectedRows);

                var coustomers = new List<Customer>
                {
                    new Customer {CustomerID=24 },
                    new Customer { CustomerID=25 },
                    new Customer {CustomerID=26 },
                };
                affectedRows = connection.Execute(sql2, coustomers);
                My.Write("delete entities: " + affectedRows);

                affectedRows = connection.Execute(sql3, new { customerid3 = new[] { 21, 22, 23 } });
                My.Write("delete list: " + affectedRows);
            }
        }

        public static void ExecuteStoredProcedure()
        {
            string sql = "proc_insert";

            using (var connection = My.ConnectionFactory())
            {
                var affectedRows = connection.Execute(sql,
                    new { CustomerName = "AA", ContactName = "BB" },
                    commandType: CommandType.StoredProcedure);
                My.Write("procedure single: " + affectedRows);

                affectedRows = connection.Execute(sql,
                  new object[] {
                    new { CustomerName = "AA", ContactName = "BB" },
                    new { CustomerName = "AA", ContactName = "BB" }
                  },
                  commandType: CommandType.StoredProcedure);
                My.Write("procedure many: " + affectedRows);
            }
        }

        public static void ExecuteReader()
        {
            using (var connection = My.ConnectionFactory())
            {
                var reader = connection.ExecuteReader("SELECT * FROM Customers;");
                DataTable table = new DataTable();
                table.Load(reader);
                My.Write("read query rows: " + table.Rows.Count);

                reader = connection.ExecuteReader("SelectAllCustomers @CustomerName = @CustomerName", new { CustomerName = "first" });
                table = new DataTable();
                table.Load(reader);
                My.Write("read procedure rows: " + table.Rows.Count);
            }
        }

        public static void ExecuteScalar()
        {
            using (var connection = My.ConnectionFactory())
            {
                var name = connection.ExecuteScalar<string>("SELECT CustomerName FROM Customers WHERE CustomerID = 1;");
                My.Write("exe scalar: " + name);
            }
        }
    }
}
