﻿using System;
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
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Create([Bind("UserId,Email,Password,ConfirmPassword,UserType")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    _context.Database.ExecuteSqlInterpolated($"InsertUsers {user.Email},{user.Password}");

                    return RedirectToAction(nameof(Login));
                }


                //_context.Add(user);
                //await _context.SaveChangesAsync();

            }
            return View(user);
        }


        //LOGIN

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(User input)
        {

            var user = _context.Users.FirstOrDefault(m => m.Email == input.Email && m.Password == input.Password);

            if (user != null)
            {

                // var SessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("CurrentUser", input.Email);


                Global.CurrentUser = HttpContext.Session.GetString("CurrentUser");
                Global.SessionId = HttpContext.Session.Id;
                return RedirectToAction("Index", "Home");


            }
            return View(input);


        }


        // GET: LOGOUT
        [HttpGet]
        public IActionResult Logout()
        {

            //HttpContext.Session.Clear;
            //var b = HttpContext.Session.GetString("CurrentUser");
            //var c = HttpContext.Session.Id;
            
            Global.CurrentUser = null;
            //Global.SessionId = null;
            //var d = HttpContext.Session.IsAvailable;

            return RedirectToAction("Index", "Home");
        }


        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,Password,UserType")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
