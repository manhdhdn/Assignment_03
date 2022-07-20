using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetails();

        public OrderDetail GetOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.GetOrderDetail(orderId, productId);

        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);

        public void DeleteOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.DeleteOrderDetail(orderId, productId);
    }
}
