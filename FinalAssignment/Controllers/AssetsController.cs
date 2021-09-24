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

    public class AssetsController : Controller
    {
        private readonly AssetDbContext _context;
        private readonly IAssetService _assetService;

        public AssetsController(AssetDbContext context,IAssetService assetService)
        {
            _context = context;
            _assetService = assetService;
        }

        // GET: Assets
        public async Task<IActionResult> Index()
        {
            //var assetDbContext = _context.Assets.Include(a => a.Facility).Include(a => a.Product);
            //return View(await assetDbContext.ToListAsync());
            return View(await _assetService.GetAllAssets());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var asset = await _context.Assets
            //    .Include(a => a.Facility)
            //    .Include(a => a.Product)
            ////    .FirstOrDefaultAsync(m => m.AssetId == id);
            //if (asset == null)
            //{
            //    return NotFound();
            //}

            return View(await _assetService.GetAssetById(id));
            //return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "FacilityType");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductType");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetId,Name,Description,ProductId,FacilityId,Location,AssetNo,ModelNo,SerialNo,PurchaseDate,PurchasePrice,EstServiceLife,BER_Maintainance_Cost,Warranty,ExpiryDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                bool result = await _assetService.CreateAsset(asset);
                //_context.Add(asset);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
       
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "FacilityType", asset.FacilityId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductType", asset.ProductId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var asset = await _context.Assets.FindAsync(id);
            var asset = await _assetService.GetAssetById(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "FacilityType", asset.FacilityId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductType", asset.ProductId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssetId,Name,Description,ProductId,FacilityId,Location,AssetNo,ModelNo,SerialNo,PurchaseDate,PurchasePrice,EstServiceLife,BER_Maintainance_Cost,Warranty,ExpiryDate")] Asset asset)
        {
            if (id != asset.AssetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(asset);
                    //await _context.SaveChangesAsync();
                    await _assetService.UpdateAsset(asset);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.AssetId))
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
            ViewData["FacilityId"] = new SelectList(_context.Facilities, "Id", "FacilityType", asset.FacilityId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductType", asset.ProductId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var asset = await _context.Assets
            //    .Include(a => a.Facility)
            //    .Include(a => a.Product)
            //    .FirstOrDefaultAsync(m => m.AssetId == id);
            var asset = await _assetService.GetAssetById(id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var asset = await _context.Assets.FindAsync(id);
            //_context.Assets.Remove(asset);
            //await _context.SaveChangesAsync();
            await _assetService.DeleteAsset(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
            //return _context.Assets.Any(e => e.AssetId == id);
            return _assetService.AssetExist(id);
        }
    }
}
