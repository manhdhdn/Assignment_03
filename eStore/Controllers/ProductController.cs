using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Repository;
using System;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository productsRepository = null;
        public ProductController() => productsRepository = new ProductRepository(); 
        // GET: ViewProductsController
        public ActionResult Product()
        {
            var productList = productsRepository.GetProducts(null, null, null);
            return View(productList);
        }

        // GET: ViewProductsController/Details/5
 

        // GET: ViewProductsController/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: ViewProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productsRepository.InsertProduct(product);
                }
                return RedirectToAction(nameof(Product));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ViewProductsController/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = productsRepository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ViewProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(int productId, Product product)
        {
            try
            {
                if(productId != product.ProductId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    productsRepository.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Product));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ViewProductsController/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = productsRepository.GetProduct(id.Value);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ViewProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int productId)
        {
            try
            {
                productsRepository.DeleteProduct(productId);
                return RedirectToAction(nameof(Product));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult SearchProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
#nullable enable
        public ActionResult SearchProduct(string? productName, decimal? fromPrice, decimal? toPrice)
        {
            try
            {
                var productList = productsRepository.GetProducts(productName, fromPrice, toPrice);
               
                return View(productList);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
