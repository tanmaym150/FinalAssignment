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
    public interface IFacilityService
    {
        public Task<List<Facility>> GetAllFcilities();
        public Task<Facility> GetFacilityById(int? id);
        public Task<bool> CreateFacility(Facility facility);
        public Task UpdateFacility(Facility facility);
        public Task DeleteFacility(int id);
        public bool FacilityExist(int id);
    }
    public class FacilityService : IFacilityService
    {
        public async Task<bool> CreateFacility(Facility facility)
        {
            using(var _context=new AssetDbContext())
            {
                try
                {
                    _context.Add(facility);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteFacility(int id)
        {
            var facility = await GetFacilityById(id);
            using(var _context=new AssetDbContext())
            {
                _context.Facilities.Remove(facility);
                await _context.SaveChangesAsync();

            }
        }

        public bool FacilityExist(int id)
        {
            using(var _context=new AssetDbContext())
            {
                return _context.Facilities.Any(m => m.Id == id);
            }
        }

        public async Task<List<Facility>> GetAllFcilities()
        {
            using(var _context =new AssetDbContext())
            {
                return await _context.Facilities.ToListAsync();
            }
        }

        public async Task<Facility> GetFacilityById(int? id)
        {
            using(var _context=new AssetDbContext())
            {
                return await _context.Facilities.FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task UpdateFacility(Facility facility)
        {
            using(var _context=new AssetDbContext())
            {
                _context.Update(facility);
                await _context.SaveChangesAsync();
            }
        }
    }
}
