using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EStore.Models;

namespace EStore.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            var CartItems = _context.Carts.Include(c => c.Product).Include(c => c.Product.Category).Where
            (c => c.Email == Global.CurrentUser && c.isChecked == false);

            if (CartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some items first");
            }

            reservation.ReservationDate = DateTime.Now;
            reservation.ReservationAmount = Global.CartTotal;
       
          
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var myId = _context.Reservations.OrderByDescending(x => x.ReservationId).First().ReservationId;


            foreach (var idetails in CartItems)
            {
                var ReservationDetail = new ReservationDetail {
                    Price = idetails.Product.Price,
                    ProductId = idetails.Product.ProductId,
                    ReservationId = myId
                    
        
                };
                _context.ReservationDetails.Add(ReservationDetail);
                
        }
            
            _context.Carts.RemoveRange(CartItems);
            await _context.SaveChangesAsync();
           
         
            
            return RedirectToAction("CheckoutComplete");


        }

        public IActionResult CheckoutComplete()
        {
          
            return View();
        }



        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public void ClearCart()
        {
            var CartItems = _context.Carts.Include(c => c.Product).Include(c => c.Product.Category).Where
            (c => c.Email == Global.CurrentUser && c.isChecked == false);


           
            _context.SaveChanges();
        }


        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
