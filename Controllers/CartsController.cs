using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EStore.Models;
using Microsoft.AspNetCore.Http;

namespace EStore.Controllers
{
    public class CartsController : Controller
    {
        private readonly AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CartItems
        public IActionResult CartItems()
        {
            //var userName = _context.Users.Select(a => a.Email).Where(a => a == Global.CurrentUser);
            
            var CartItems = _context.Carts.Include(c => c.Product).Include(c=>c.Product.Category).Where
            (c => c.Email == Global.CurrentUser && c.isChecked == false);

           Global.CartTotal = CartTotal();

            return View( CartItems.ToList());
        }

       
        //POST - ADD to Cart
        [HttpPost]
      
        public IActionResult AddToCart(int productId)
        {
            if (Global.CurrentUser == null) {
                RedirectToAction("Login", "Users");

            }
            else
            {
                var currentUser = HttpContext.Session.GetString("CurrentUser");

                var SessionId = HttpContext.Session.Id;

                var cartItems = new Cart();

                cartItems.CartNumber = SessionId;
                cartItems.isChecked = false;
                cartItems.Email = currentUser;
                cartItems.ProductId = productId;

                _context.Carts.Add(cartItems);
                var bb = _context.SaveChanges();

                return RedirectToAction("CartItems", "Carts");

            }
            return RedirectToAction("Login", "Users");




        }

      

     
        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        public decimal CartTotal()
        {
            var total = _context.Carts.Where(c => c.Email == Global.CurrentUser && c.isChecked == false)
                .Select(c => c.Product.Price).Sum();
            return total;
        }

    

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CartItems));
        }

        //public List<Cart> GetCartItems()
        //{
        //    return Carts ??
        //           (Carts =
        //               _context.Carts.Where(c => c.CartId ==)
        //                   .Include(s => s.Product)
        //                   .ToList());
        //}

        public void ClearCart()
        {
            var CartClearItems = _context.Carts.Include(c => c.Product).Where
            (c => c.Email == Global.CurrentUser && c.isChecked == true);
           
            _context.Carts.RemoveRange(CartClearItems);

            _context.SaveChanges();
        }


        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
