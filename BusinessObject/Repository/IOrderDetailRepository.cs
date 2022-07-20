using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();

        OrderDetail GetOrderDetail(int orderId, int productId);

        void InsertOrderDetail(OrderDetail orderDetail);

        void UpdateOrderDetail(OrderDetail orderDetail);

        void DeleteOrderDetail(int orderId, int productId);
    }
}
