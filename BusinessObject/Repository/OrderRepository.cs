using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrders(int? memberId, DateTime? startDate, DateTime? endDate) => OrderDAO.Instance.GetOrders(memberId, startDate, endDate);

        public Order GetOrder(int orderId) => OrderDAO.Instance.GetOrder(orderId);

        public void InsertOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);

        public void DeleteOrder(int orderId) => OrderDAO.Instance.DeleteOrder(orderId);
    }
}
