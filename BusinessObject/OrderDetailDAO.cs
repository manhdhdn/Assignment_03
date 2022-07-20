using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }

                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            try
            {
                using FStore2Context context = new();

                return context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderDetail GetOrderDetail(int orderId, int productId)
        {
            try
            {
                using FStore2Context context = new();

                var orderDetail = context.OrderDetails.FirstOrDefault(o => o.OrderId == orderId && o.ProductId == productId);

                if (orderDetail == null)
                {
                    throw new Exception("Not found.");
                }

                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using FStore2Context context = new();

                if (context.OrderDetails.Any(m => m.OrderId == orderDetail.OrderId && m.ProductId == orderDetail.ProductId))
                {
                    throw new Exception("Already exists.");
                }

                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using FStore2Context context = new();

                if (context.OrderDetails.Any(m => m.OrderId == orderDetail.OrderId && m.ProductId == orderDetail.ProductId))
                {
                    throw new Exception("Not exists.");
                }

                context.OrderDetails.Update(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            try
            {
                using FStore2Context context = new();

                var orderDetail = GetOrderDetail(orderId, productId);

                if (context.OrderDetails.Any(m => m.OrderId == orderDetail.OrderId && m.ProductId == orderDetail.ProductId))
                {
                    throw new Exception("Not exists.");
                }

                context.OrderDetails.Remove(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
