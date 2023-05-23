using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreshMart.Data;
using FreshMart.Models;
using FreshMart.Services.Interfaces;
using static NuGet.Packaging.PackagingConstants;
using Microsoft.AspNetCore.Authorization;

namespace FreshMart.Controllers
{
    [Authorize(Roles ="Administrator,User")]
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderAndRelatedById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var customers = _orderService.GetAllCustomers();
            var shoppingCarts = _orderService.GetAllShoppingCarts();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "LastName");
            ViewData["ShoppingCartId"] = new SelectList(shoppingCarts, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,Code,CustomerId,ShoppingCartId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            var customers = _orderService.GetAllCustomers();
            var shoppingCarts = _orderService.GetAllShoppingCarts();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "LastName", order.CustomerId);
            ViewData["ShoppingCartId"] = new SelectList(shoppingCarts, "Id", "Id", order.ShoppingCartId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderById(id.Value);
            if (_orderService == null)
            {
                return NotFound();
            }
            var customers = _orderService.GetAllCustomers();
            var shoppingCarts = _orderService.GetAllShoppingCarts();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "LastName", order.CustomerId);
            ViewData["ShoppingCartId"] = new SelectList(shoppingCarts, "Id", "Id", order.ShoppingCartId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,Code,CustomerId,ShoppingCartId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.UpdateOrder(order);  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_orderService.OrderExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var customers = _orderService.GetAllCustomers();
            var shoppingCarts = _orderService.GetAllShoppingCarts();
            ViewData["CustomerId"] = new SelectList(customers, "Id", "LastName", order.CustomerId);
            ViewData["ShoppingCartId"] = new SelectList(shoppingCarts, "Id", "Id", order.ShoppingCartId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.GetOrderAndRelatedById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var order = _orderService.GetOrderById(id);

            if (order != null)
            {
                _orderService.DeleteOrder(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
