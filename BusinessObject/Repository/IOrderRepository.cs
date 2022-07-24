using DataAccess.Models;
using System.Collections.Generic;
using System;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders(int? memberId, DateTime? startDate, DateTime? endDate);

        Order GetOrder(int orderId);

        void InsertOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(int orderId);
    }
}
