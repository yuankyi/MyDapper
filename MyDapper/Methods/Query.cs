using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MyDapper.Methods
{
    public class Query
    {
        public static void QueryCommon()
        {
            string sql = "SELECT TOP 10 * FROM OrderDetails";
            string sql2 = "SELECT TOP 10 * FROM OrderDetails where orderid in @orderids";

            using (var connection = My.ConnectionFactory())
            {
                var anonymous = connection.Query(sql).FirstOrDefault();
                My.Write("query anonymous");

                var orderDetails = connection.Query<OrderDetail>(sql).ToList();
                My.Write("query strongly typed: " + orderDetails.Count);

                var orderDetails2 = connection.Query<OrderDetail>(sql2, new { orderids = new[] { 1, 2 } }).ToList();
                My.Write("query list: " + orderDetails2.Count);
            }
        }

        public static void QueryMultiType()
        {
            string sql = "SELECT TOP 10 * FROM OrderDetails";

            using (var connection = My.ConnectionFactory())
            {
                var orderDetails2 = new List<OrderDetail>();
                using (var reader = connection.ExecuteReader(sql))
                {
                    var orderDetailParser = reader.GetRowParser<OrderDetail>();

                    while (reader.Read())
                    {
                        OrderDetail od;
                        od = orderDetailParser(reader);
                        orderDetails2.Add(od);
                    }
                }
                My.Write("query multi-type: " + orderDetails2.Count);
            }
        }

        public static void QueryMultiMapping()
        {
            string sql = "SELECT TOP 10 * FROM OrderDetails";

            using (var connection = My.ConnectionFactory())
            {
                var sql2 = "select * from Orders o join Customers c on o.CustomerId=c.CustomerId;";
                var orders = connection.Query<Order, Customer, Order>(sql2,
                    (order, customer) =>
                    {
                        order.Customer = customer;
                        return order;
                    }, splitOn: "CustomerId")
                    .ToList();

                My.Write("query multi-mapping (one to one): " + orders.Count);

                var sql3 = "select * from orders o left join orderdetails d on o.orderid=d.orderid";
                //var orderDictionary = new Dictionary<int, Order>();
                //var orders2 = connection.Query<Order, OrderDetail, Order>(sql3,
                //    (order, orderDetail) =>
                //    {
                //        Order orderEntry;

                //        if (!orderDictionary.TryGetValue(order.OrderID, out orderEntry))
                //        {
                //            orderEntry = order;
                //            orderEntry.OrderDetails = new List<OrderDetail>();
                //            orderDictionary.Add(orderEntry.OrderID, orderEntry);
                //        }

                //        orderEntry.OrderDetails.Add(orderDetail);
                //        return orderEntry;
                //    }, splitOn: "OrderID")
                //    .Distinct()//需要去重或者用外部集合保存
                //    .ToList();
                var orders2 = new List<Order>();
                connection.Query<Order, OrderDetail, Order>(sql3,
                    (order, orderDetail) =>
                    {
                        Order orderEntry = orders2.FirstOrDefault(m => m.OrderID == order.OrderID);

                        if (orderEntry == null)
                        {
                            orderEntry = order;
                            orderEntry.OrderDetails = new List<OrderDetail>();
                            orders2.Add(orderEntry);
                        }

                        orderEntry.OrderDetails.Add(orderDetail);
                        return null;//无所谓了
                    }, splitOn: "OrderID");

                My.Write("query multi-mapping (one to many): " + orders2.Count);

                var sql4 = @"
                select * from orders o 
                left join customers c on o.customerid=c.customerid
                left join orderdetails d on o.orderid=d.orderid";
                var orders3 = new List<Order>();
                connection.Query<Order, Customer, OrderDetail, Order>(sql4,
                    (order, customer, orderDetail) =>
                    {
                        Order orderEntry = orders3.FirstOrDefault(m => m.OrderID == order.OrderID);

                        if (orderEntry == null)
                        {
                            orderEntry = order;
                            orderEntry.Customer = customer;
                            orderEntry.OrderDetails = new List<OrderDetail>();
                            orders3.Add(orderEntry);
                        }

                        orderEntry.OrderDetails.Add(orderDetail);
                        return null;//无所谓了
                    }, splitOn: "CustomerId,OrderID");//多个对象关联时,关联字段按顺序排列
                My.Write("query multi-mapping (one to many): " + orders3.Count);
            }
        }

        public static void QueryFirst()
        {
            string sql = "select * from orderdetails where orderid = @OrderId;";

            using (var connection = My.ConnectionFactory())
            {
                //First不存在时会报错,FirstOrDefault不存在时会给个默认值
                var orderDetail = connection.QueryFirst(sql, new { OrderId = 1 });
                My.Write("query first anonymous: " + orderDetail);
                var orderDetail1 = connection.QueryFirstOrDefault(sql, new { OrderId = 111 });
                My.Write("query first or default anonymous: " + (orderDetail1 ?? "null"));

                var orderDetail2 = connection.QueryFirst<OrderDetail>(sql, new { OrderId = 1 });
                My.Write("query first strongly typed: " + orderDetail2);
                var orderDetail22 = connection.QueryFirstOrDefault<OrderDetail>(sql, new { OrderId = 111 });
                My.Write("query first or default strongly typed: " + (orderDetail22 == null ? "null" : orderDetail22.ToString()));
            }
        }

        public static void QuerySingle()
        {
            string sql = "select * from orderdetails where OrderId = @OrderId;";

            using (var connection = My.ConnectionFactory())
            {
                //Single比First更严格,没有或多个都会报错
                var orderDetail = connection.QuerySingle<OrderDetail>(sql, new { OrderId = 2 });
                My.Write("query single: " + orderDetail);

                var orderDetail2 = connection.QuerySingleOrDefault<OrderDetail>(sql, new { OrderId = 111 });
                My.Write("query single or default: " + (orderDetail2 == null ? "null" : orderDetail2.ToString()));
            }
        }

        /// <summary>
        /// 多个sql解析出多个对象
        /// </summary>
        public static void QueryMultipleResult()
        {
            string sql = "select * from orders where OrderId = @OrderId;select * from orderdetails where OrderId = @OrderId;";

            using (var connection = My.ConnectionFactory())
            {
                using (var multi = connection.QueryMultiple(sql, new { OrderId = 1 }))
                {
                    var order = multi.Read<Order>().First();
                    My.Write("query multiple order: " + order);

                    var details = multi.Read<OrderDetail>().ToList();
                    My.Write("query multiple orderdetails: " + details.Count);
                }
            }
        }
    }
}
