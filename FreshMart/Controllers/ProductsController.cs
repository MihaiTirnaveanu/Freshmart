using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreshMart.Models;
using FreshMart.Data;
using FreshMart.Repositories.Interfaces;
using FreshMart.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FreshMart.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ProductsController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: Products
        [AllowAnonymous]
        public IActionResult Index(string productName)
        {
            var products = _productService.GetAllProducts();
            if (String.IsNullOrEmpty(productName))
            {
                return View(products);
            } else
            {
                var searchItems = _productService.GetSearchedProducts(productName);
                return View(searchItems);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult FilteredByCategory(int categoryId)
        {
            // Retrieve products based on the categoryId and pass them to the view
            var products = _productService.GetProductsByCategoryId(categoryId);
            return View(products);
        }


        // GET: Products/Details/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductAndRelatedById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var categories = _productService.GetAllCategories();
            var suppliers = _productService.GetAllSuppliers();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([Bind("Id,Price,Name,CategoryId,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryService.GetCategoryById(product.CategoryId);
                product.Category = category;
                _productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            var categories = _productService.GetAllCategories();
            var suppliers = _productService.GetAllSuppliers();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            var categories = _productService.GetAllCategories();
            var suppliers = _productService.GetAllSuppliers();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, [Bind("Id,Price,Name,CategoryId,SupplierId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productService.ProductExists(id))
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
            var categories = _productService.GetAllCategories();
            var suppliers = _productService.GetAllSuppliers();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductAndRelatedById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
