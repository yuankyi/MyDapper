using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MyDapper.Methods
{
    public class Contrib
    {
        public static void Method()
        {
            using (var connection = My.ConnectionFactory())
            {
                //Get<T> only supports an entity with a [Key] or an [ExplicitKey] property
                var customer = connection.Get<Customer>(1);
                My.Write("get : " + customer.CustomerName + "," + customer.Country + "," + customer.City + "," + customer.PostalCode);

                var customers = connection.GetAll<Customer>().ToList();
                My.Write("get all : " + customers.Count);

                var identity = connection.Insert(new Customer { CustomerName = "Lacey", ContactName = "Lea" });
                My.Write("insert single : " + identity);

                //Entity to insert, can be list of entities
                var affectedRows = connection.Insert(
                  new List<Customer>
                  {
                      //Country write=false , 不会保存到数据库
                        new Customer { CustomerName = "Magdalen", ContactName = "Mae",City = "guangzhou",Country = "chinan",PostalCode="12345" },
                        new Customer { CustomerName = "Magdalen", ContactName = "Mae",City = "guangzhou",Country = "chinan",PostalCode="12345" }
                  });
                My.Write("insert many : " + affectedRows);

                var isSuccess = connection.Update(new Customer
                {
                    CustomerID = 11,
                    CustomerName = "Lacey",
                    ContactName = "Lea",
                    City = "guangzhou",
                    Country = "chinan",//Country write=false , 不会保存到数据库
                    PostalCode = "12345",
                });
                My.Write("update single : " + isSuccess);

                isSuccess = connection.Update(
                  new List<Customer>
                  {
                        new Customer { CustomerID=13, CustomerName = "Magdalen", ContactName = "Mae" },
                        new Customer {CustomerID=14, CustomerName = "Magdalen", ContactName = "Mae" }
                  });
                My.Write("update many : " + isSuccess);

                isSuccess = connection.Delete(new Customer { CustomerID = 12 });
                My.Write("delete single : " + isSuccess);

                isSuccess = connection.Delete(
                  new List<Customer>
                  {
                        new Customer { CustomerID=15},
                        new Customer {CustomerID=16 }
                  });
                My.Write("delete many : " + isSuccess);

                //isSuccess = connection.DeleteAll<Customer>();
            }

        }
    }
}
