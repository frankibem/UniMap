using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniMap.Data;
using UniMap.Models;
using UniMap.DataAccess;

namespace UniMap.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public AdminController(ApplicationDbContext context)
        {
            _eventRepository = new EventRepository(context);
        }

        // GET: Admin
        public IActionResult Index()
        {
            return View(_eventRepository.GetEvents());
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Address,Description,EndOn,Latitude,Longitude,StartOn,Title")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.CreateEvent(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        //// GET: Admin/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.ID == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Admin/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Address,Description,EndOn,Latitude,Longitude,StartOn,Title")] Event @event)
        //{
        //    if (id != @event.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(@event);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EventExists(@event.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(@event);
        //}

        //// GET: Admin/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.ID == id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@event);
        //}

        //// POST: Admin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var @event = await _context.Events.SingleOrDefaultAsync(m => m.ID == id);
        //    _context.Events.Remove(@event);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool EventExists(int id)
        //{
        //    return _context.Events.Any(e => e.ID == id);
        //}
    }
}
