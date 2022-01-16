using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace MyDapper.Methods
{
    /// <summary>
    /// using Z.Dapper.Plus;
    /// </summary>
    public class Bulk
    {
        public static void BulkInsert()
        {
            //[Table("Customers")]
            DapperPlusManager.Entity<Customer>();//.Table("Customers");
            //Identity:Sets identity accessor from the selectors. 加了才会回写对象属性值
            DapperPlusManager.Entity<Supplier>().Table("Suppliers").Identity(m => m.SupplierID);
            DapperPlusManager.Entity<Product>().Table("Products").Identity(m => m.ProductID);

            var customer = new Customer() { CustomerName = "insert", ContactName = "Single" };

            var customers = new List<Customer>();
            customers.Add(new Customer() { CustomerName = "insert", ContactName = "Many" + 1 });
            customers.Add(new Customer() { CustomerName = "insert", ContactName = "Many" + 2 });

            var suppliers = new List<Supplier>();
            suppliers.Add(new Supplier { SupplierName = "S001", MainProduct = new Product { ProductName = "P001" } });
            suppliers.Add(new Supplier { SupplierName = "S002", MainProduct = new Product { ProductName = "P002" } });

            var supplier = new Supplier
            {
                SupplierName = "S003",
                Products = new List<Product>
                {
                    new Product { ProductName = "P003" },
                    new Product { ProductName = "P004" },
                    new Product { ProductName = "P005" },
                }
            };

            using (var connection = My.ConnectionFactory())
            {
                connection.BulkInsert(customer);
                My.Write("bulk insert single");

                connection.BulkInsert(customers);
                My.Write("bulk insert many");

                connection.BulkInsert(suppliers).ThenForEach(m => m.MainProduct.SupplierID = m.SupplierID).ThenBulkInsert(x => x.MainProduct);
                My.Write("bulk insert with relation (one to one)");

                //处理逻辑从单个对象到List集合,ThenBulkInsert传入的也是集合
                connection.BulkInsert(supplier).ThenForEach(m => m.Products.ForEach(x => x.SupplierID = m.SupplierID)).ThenBulkInsert(x => x.Products);
                My.Write("bulk insert with relation (one to many)");
            }
        }

        public static void BulkUpdate()
        {
            //建立对象与表的映射关系
            DapperPlusManager.Entity<Customer>().Table("Customers");
            //Identity:Sets identity accessor from the selectors. 加了才会回写对象属性值
            DapperPlusManager.Entity<Supplier>().Table("Suppliers").Identity(m => m.SupplierID);
            DapperPlusManager.Entity<Product>().Table("Products").Identity(m => m.ProductID);

            var customer = new Customer() { CustomerID = 202, CustomerName = "update" };

            var customers = new List<Customer>();
            customers.Add(new Customer() { CustomerID = 203, CustomerName = "update" });
            customers.Add(new Customer() { CustomerID = 204, CustomerName = "update" });

            var supplier1 = new Supplier
            {
                SupplierID = 26,
                SupplierName = "SXX03",
                MainProduct = new Product { ProductID = 23, SupplierID = 24, ProductName = "PX003" }
            };
            var suppliers = new List<Supplier> { supplier1 };

            var supplier2 = new Supplier
            {
                SupplierID = 27,
                SupplierName = "SX004",
                Products = new List<Product>
                {
                    new Product {ProductID=26,SupplierID = 27, ProductName = "PX003" },
                    new Product {ProductID=27,SupplierID = 27, ProductName = "PX004" },
                }
            };

            using (var connection = My.ConnectionFactory())
            {
                //更新所有字段,包括值为null的字段
                connection.BulkUpdate(customer);
                My.Write("bulk udpate single");

                connection.BulkUpdate(customers);
                My.Write("bulk udpate many");

                //connection.BulkUpdate(supplier1, x => x.MainProduct);
                My.Write("bulk udpate with relation (one to one / single)");

                //BulkUpdate<T>(this IDbConnection connection, IEnumerable<T> items, params Func<T, object>[] selectors);
                connection.BulkUpdate(suppliers, x => x.MainProduct);
                My.Write("bulk udpate with relation (one to one / many)");

                connection.BulkUpdate(supplier2, x => x.Products);
                My.Write("bulk udpate with relation (one to many)");
            }
        }

        public static void BulkDelete()
        {
            //建立对象与表的映射关系
            DapperPlusManager.Entity<Customer>().Table("Customers");
            //Identity:Sets identity accessor from the selectors. 加了才会回写对象属性值
            DapperPlusManager.Entity<Supplier>().Table("Suppliers");//.Identity(m => m.SupplierID);
            DapperPlusManager.Entity<Product>().Table("Products");//.Identity(m => m.ProductID);

            var customer = new Customer() { CustomerID = 132 };

            var customers = new List<Customer>();
            customers.Add(new Customer() { CustomerID = 133 });
            customers.Add(new Customer() { CustomerID = 134 });

            var supplier1 = new Supplier
            {
                SupplierID = 16,
                MainProduct = new Product { ProductID = 16 }
            };
            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierID = 17,
                    MainProduct = new Product { ProductID = 17}
                },
                new Supplier
                {
                    SupplierID = 18,
                    MainProduct = new Product { ProductID = 18}
                }
            };

            var supplier2 = new Supplier
            {
                SupplierID = 19,
                Products = new List<Product>
                {
                    new Product {ProductID=19  },
                    new Product {ProductID=20 },
                }
            };

            using (var connection = My.ConnectionFactory())
            {
                connection.BulkDelete(customer);
                My.Write("bulk delete single");

                connection.BulkDelete(customers);
                //connection.BulkDelete(connection.Query<Customer>("Select * FROM CUSTOMERS WHERE CustomerID in (53,57) ").ToList());
                My.Write("bulk delete many");

                //按依赖关系执行多次删除
                connection.BulkDelete(supplier1.MainProduct).BulkDelete(supplier1);
                My.Write("bulk delete with relation (one to one / single)");

                connection.BulkDelete(suppliers.Select(m => m.MainProduct)).BulkDelete(suppliers);
                My.Write("bulk delete with relation (one to one / many)");

                connection.BulkDelete(supplier2.Products).BulkDelete(supplier2);
                My.Write("bulk delete with relation (one to many)");
            }
        }

        /// <summary>
        /// An IDbConnection extension method to MERGE (Upsert) entities in a database table or a view.
        /// </summary>
        public static void BulkMerge()
        {
            //建立对象与表的映射关系
            DapperPlusManager.Entity<Customer>().Table("Customers");
            //Identity:Sets identity accessor from the selectors. 加了才会回写对象属性值
            DapperPlusManager.Entity<Supplier>().Table("Suppliers").Identity(m => m.SupplierID);
            DapperPlusManager.Entity<Product>().Table("Products").Identity(m => m.ProductID);

            //update
            var customer = new Customer() { CustomerID = 30, CustomerName = "Lux", ContactName = "Lux" };

            var customers = new List<Customer>();
            //update
            customers.Add(new Customer() { CustomerID = 31, CustomerName = "Diana", ContactName = "Diana" });
            customers.Add(new Customer() { CustomerID = 32, CustomerName = "Leona", ContactName = "Leona" });
            //insert
            customers.Add(new Customer() { CustomerName = "Fiora", ContactName = "Fiora" });

            var supplier1 = new Supplier
            {
                SupplierID = 29,
                SupplierName = "SX001",
                MainProduct = new Product { ProductID = 30, SupplierID = 29, ProductName = "PX001" }
            };
            var suppliers = new List<Supplier>
            {
                new Supplier
                {
                    SupplierID = 31,
                    SupplierName = "SX002",
                    MainProduct = new Product { ProductID = 34,SupplierID = 31, ProductName = "PX002" }
                },
                new Supplier
                {
                    SupplierID = 32,
                    SupplierName = "SX003",
                    MainProduct = new Product { ProductID = 35, SupplierID = 32,ProductName = "PX003"}
                },
                new Supplier
                {
                    SupplierName = "SX004",
                    MainProduct = new Product {ProductName = "PX004"}
                }
            };

            var supplier2 = new Supplier
            {
                SupplierID = 30,
                SupplierName = "SX005",
                Products = new List<Product>
                {
                    new Product {ProductID=31 , SupplierID = 30,ProductName = "PX005" },
                    new Product {ProductID=32, SupplierID = 30,ProductName = "PX005" }
                }
            };

            using (var connection = My.ConnectionFactory())
            {
                connection.BulkMerge(customer);
                My.Write("bulk merge single");

                //同时执行update和insert
                connection.BulkMerge(customers);
                My.Write("bulk merge many");

                connection.BulkMerge(supplier1).BulkMerge(supplier1.MainProduct);
                My.Write("bulk merge with relation (one to one / single)");

                connection.BulkMerge(suppliers).BulkMerge(suppliers.Select(m => m.MainProduct));
                connection.BulkMerge(suppliers).ThenForEach(m => m.MainProduct.SupplierID = m.SupplierID).ThenBulkMerge(x => x.MainProduct);
                My.Write("bulk merge with relation (one to one / many)");

                connection.BulkMerge(supplier2.Products).BulkMerge(supplier2);
                My.Write("bulk merge with relation (one to many)");
            }
        }
    }
}
