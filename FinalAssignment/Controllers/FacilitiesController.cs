using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAssignment.DAL.Data.Model;
using FinalAssignment.Data;
using FinalAssignment.Services.Services;

namespace FinalAssignment.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly AssetDbContext _context;
        private readonly IFacilityService _facilityService;

        public FacilitiesController(AssetDbContext context,IFacilityService facilityService)
        {
            _context = context;
            _facilityService = facilityService;
        }

        // GET: Facilities
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Facilities.ToListAsync());
            return View(await _facilityService.GetAllFcilities());
        }

        // GET: Facilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var facility = await _context.Facilities
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (facility == null)
            //{
            //    return NotFound();
            //}
            return View(await _facilityService.GetFacilityById(id));
            //return View(facility);
        }

        // GET: Facilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacilityType")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                bool result = await _facilityService.CreateFacility(facility);
                //_context.Add(facility);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                
            }
            
            return View(facility);
        }

        // GET: Facilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var facility = await _context.Facilities.FindAsync(id);
            var facility = await _facilityService.GetFacilityById(id);

            if (facility == null)
            {
                return NotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FacilityType")] Facility facility)
        {
            if (id != facility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(facility);
                    //await _context.SaveChangesAsync();
                    await _facilityService.UpdateFacility(facility);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.Id))
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
            return View(facility);
        }

        // GET: Facilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var facility = await _context.Facilities
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var facility = await _facilityService.GetFacilityById(id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var facility = await _context.Facilities.FindAsync(id);
            //_context.Facilities.Remove(facility);
            //await _context.SaveChangesAsync();
            await _facilityService.DeleteFacility(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return _context.Facilities.Any(e => e.Id == id);
        }
    }
}
