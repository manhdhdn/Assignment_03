using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepository = null;
        public OrderController() => orderRepository = new OrderRepository();
        // GET: OrderController
        public ActionResult OrderPage()
        {
            IEnumerable<Order> orderList = null!;
            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                orderList = orderRepository.GetOrders(memberID);

            }
            else
            {
                orderList = orderRepository.GetOrders(null);               
            }
            return View(orderList);
        }

        // GET: OrderController/Details/5
        public ActionResult OrderDetails(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrder(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult CreateOrder()
        {
            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                return RedirectToAction(nameof(OrderPage));
            }
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderRepository.InsertOrder(order);
                }
                return RedirectToAction(nameof(OrderPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(order);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult EditOrder(int? id)
        {
            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                return RedirectToAction(nameof(OrderPage));
            }
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrder(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(int orderId, Order order)
        {
            try
            {
                if (orderId != order.OrderId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    orderRepository.UpdateOrder(order);
                }
                return RedirectToAction(nameof(OrderPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult DeleteOrder(int? id)
        {
            var memberID = HttpContext.Session.GetInt32("MemberID");
            if (memberID != 0)
            {
                return RedirectToAction(nameof(OrderPage));
            }
            if (id == null)
            {
                return NotFound();
            }
            var order = orderRepository.GetOrder(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(int orderId, IFormCollection collection)
        {
            try
            {
                orderRepository.DeleteOrder(orderId);
                return RedirectToAction(nameof(OrderPage));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
