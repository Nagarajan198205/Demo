using System.Collections.Generic;
using System.Linq;

namespace Boots.Models
{
    /// <summary>
    /// Order data repository
    /// </summary>
    public class OrderRepository
    {
        private static List<OrderModel> _orderDb;

        private static List<OrderModel> OrderDb
        {
            get { return _orderDb ?? (_orderDb = new List<OrderModel>()); }
        }

        /// <summary>
        /// Gets the Orders.
        /// </summary>
        /// <returns>IEnumerable Order List</returns>
        public static List<OrderModel> GetOrders()
        {
            return OrderDb;
        }

        /// <summary>
        /// Inserts the Order to database.
        /// </summary>
        /// <param name="Order">The Order object to insert.</param>
        public static void AddOrder(OrderModel Order)
        {
            OrderDb.Add(Order);
        }

        /// <summary>
        /// Deletes Order from database.
        /// </summary>
        /// <param name="orderId">Order ID</param>
        public static void DeleteOrder(string id)
        {
            var deleteItem = OrderDb.FirstOrDefault(c => c.Id == id);

            if (deleteItem != null)
            {
                OrderDb.Remove(deleteItem);
            }
        }
    }
}