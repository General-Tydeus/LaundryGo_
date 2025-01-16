using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaundryGo.Data;
using LaundryGo.Models;
using Microsoft.AspNetCore.Authorization;

namespace LaundryGo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        int userID;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Products
        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["UserId"] = id;
            var products = _context.Products.Where(p => p.UserId == id.ToString()).ToList();
            return View(products);
        }
        [Authorize]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["UserId"] = id;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Price,Availability,UserId")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = products.UserId });
            }
            return View(products);
        }

        // GET: Products/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id, int UserId)
        {
            ViewData["UserId"] = UserId;
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Price,Availability,UserId")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = products.UserId });
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id, int UserId)
        {
            ViewData["UserId"] = UserId;
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = products.UserId });
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


        [HttpGet]
        public JsonResult GetProductDetails(int productId)
        {
            // Query to get products based on productId or other criteria
            var products = _context.Products
                                   .Where(p => p.UserId == productId.ToString()) // Adjust this query based on your requirements
                                   .ToList(); // Make sure you get a list of products

            if (products.Any()) // Check if there are products
            {
                // Return multiple products' details
                var productDetails = products.Select(p => new
                {
                    productName = p.ProductName,
                    price = p.Price,
                    availability = p.Availability,
                }).ToList();

                return Json(productDetails); // Return a list of products
            }

            return Json(null); // Return null if no data found
        }


    }
}
