using FinalAssignment.DAL.Data.Model;
using FinalAssignment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.Services.Services
{
    public interface IAssetService
    {
        public Task<List<Asset>> GetAllAssets();
        public Task<Asset> GetAssetById(int? id);
        public Task<bool> CreateAsset(Asset asset);
        public Task UpdateAsset(Asset asset);
        public Task DeleteAsset(int id);
        public bool AssetExist(int id);

    }
    public  class AssetService : IAssetService
    {
        public bool AssetExist(int id)
        {
            using(var _context=new AssetDbContext())
            {
                return _context.Assets.Any(m => m.AssetId == id);
            }
        }

        public async Task<bool> CreateAsset(Asset asset)
        {
            using(var _context=new AssetDbContext())
            {
                try
                {
                    _context.Add(asset);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteAsset(int id)
        {
            var asset = await GetAssetById(id);
           using(var _context=new AssetDbContext())
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Asset>> GetAllAssets()
        {
            using (var _context = new AssetDbContext())
            {
                var joinContext = _context.Assets.Include(a => a.Facility).Include(a => a.Product);
                return await joinContext.ToListAsync();
            }
        }

        public async Task<Asset> GetAssetById(int? id)
        {
            using(var _context=new AssetDbContext())
            {
                return await _context.Assets.Include(a => a.Product).Include(a => a.Facility).FirstOrDefaultAsync(m => m.AssetId == id);
            }
        }

        public async Task UpdateAsset(Asset asset)
        {
            using(var _context=new AssetDbContext())
            {
                _context.Update(asset);
                await _context.SaveChangesAsync();
            }
        }
    }
}
