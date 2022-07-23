using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }

                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrders(int? memberId)
        {
            try
            {
                using FStore2Context context = new();

                var orders = context.Orders.AsQueryable();

                if (memberId != null)
                {
                    orders = orders.Where(o => o.MemberId == memberId);
                }

                return orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Order GetOrder(int orderId)
        {
            try
            {
                using FStore2Context context = new();

                var order = context.Orders.Find(orderId);

                if (order == null)
                {
                    throw new Exception("Not found.");
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                using FStore2Context context = new();

                if (context.Orders.Any(m => m.OrderId == order.OrderId))
                {
                    throw new Exception("Already exists.");
                }

                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using FStore2Context context = new();

                if (!context.Orders.Any(m => m.OrderId == order.OrderId))
                {
                    throw new Exception("Not exists.");
                }

                context.Orders.Update(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrder(int orderId)
        {
            try
            {
                using FStore2Context context = new();

                var order = GetOrder(orderId);

                if (!context.Orders.Any(m => m.OrderId == order.OrderId))
                {
                    throw new Exception("Not exists.");
                }

                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
