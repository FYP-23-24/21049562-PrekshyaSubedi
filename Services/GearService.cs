using Microsoft.EntityFrameworkCore;
using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;

namespace MitraNepAdven.Services
{
    public class GearService : IGearService
    {
        private readonly JwtContext _context;

        public GearService(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<Gear>> GetAllGearsAsync()
        {
            return await _context.Gears.ToListAsync();
        }

        public async Task<Gear> GetGearByIdAsync(int id)
        {
            return await _context.Gears.FindAsync(id);
        }

        public async Task<Gear> AddGearAsync(Gear gear)
        {
            var addedGear = _context.Gears.Add(gear);
            await _context.SaveChangesAsync();
            return addedGear.Entity;
        }

        public async Task<bool> UpdateGearAsync(int id, Gear gear)
        {
            var existingGear = await _context.Gears.FindAsync(id);
            if (existingGear == null)
                return false;

            existingGear.Name = gear.Name;
            existingGear.Description = gear.Description;
            // Update other properties as needed

            _context.Gears.Update(existingGear);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGearAsync(int id)
        {
            var gear = await _context.Gears.FindAsync(id);
            if (gear == null)
                return false;

            _context.Gears.Remove(gear);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
