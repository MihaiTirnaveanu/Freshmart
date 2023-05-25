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
using Microsoft.AspNetCore.Authorization;
using System.Data;
using FreshMart.Services;

namespace FreshMart.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ShoppingCartsController : Controller
    {
        private IShoppingCartService _shoppingCartService;
        private IProductService _productService;
        private ICartItemService _cartItemService;

        public ShoppingCartsController(
            IShoppingCartService shoppingCartService, 
            IProductService productService,
            ICartItemService cartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _cartItemService = cartItemService;
        }

        // GET: ShoppingCarts
        public IActionResult Index()
        {
            var shoppingCart = _shoppingCartService.GetExistingShoppingCart();
            _shoppingCartService.LoadCartCollection(shoppingCart);
            return View(shoppingCart);
        }


        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var shoppingCart = _shoppingCartService.GetExistingShoppingCart();

            var product = _productService.GetProductById(productId);
            var cartItem = new CartItem
            {
                Quantity = quantity,
                ProductId = productId,
                Product = product,
                ShoppingCartId = shoppingCart.Id,
                ShoppingCart = shoppingCart
            };
            _shoppingCartService.AddCartItem(shoppingCart, cartItem);

            return RedirectToAction("Index");
        }


        // GET: ShoppingCarts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _shoppingCartService.GetShoppingCartById(id.Value);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Size,Ammount")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _shoppingCartService.AddShoppingCart(shoppingCart);
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _shoppingCartService.GetShoppingCartById(id.Value);

            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Size,Ammount")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _shoppingCartService.UpdateShoppingCart(shoppingCart);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_shoppingCartService.ShoppingCartExists(id))
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
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = _shoppingCartService.GetShoppingCartById(id.Value);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _shoppingCartService.DeleteShoppingCart(id);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int cartItemId)
        {
            var cartItem = _cartItemService.GetCartItemById(cartItemId);

            if (cartItem != null)
            {
                var shoppingCart = _shoppingCartService.GetShoppingCartById(cartItem.ShoppingCartId);
                if (shoppingCart != null)
                {
                    _shoppingCartService.removeCartItem(shoppingCart, cartItem);
                    //_cartItemService.DeleteCartItem(cartItem); 
                }
            }

            return RedirectToAction("Index");
        }
    }
}
