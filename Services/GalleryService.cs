using Microsoft.EntityFrameworkCore;
using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;

namespace MitraNepAdven.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly JwtContext _context;

        public GalleryService(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<Gallery>> GetAllGalleryAsync()
        {
            return await _context.Gallery.ToListAsync();
        }

        public async Task<Gallery> GetGalleryByIdAsync(int id)
        {
            return await _context.Gallery.FindAsync(id);
        }

        public async Task<Gallery> AddGalleryAsync(Gallery item)
        {
            var addedItem = _context.Gallery.Add(item);
            await _context.SaveChangesAsync();
            return addedItem.Entity;
        }

        public async Task<bool> UpdateGalleryAsync(int id, Gallery item)
        {
            var existingItem = await _context.Gallery.FindAsync(id);
            if (existingItem == null)
                return false;

            existingItem.Title = item.Title;
            existingItem.ImageUrl = item.ImageUrl;
            // Update other properties as needed

            _context.Gallery.Update(existingItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGalleryAsync(int id)
        {
            var item = await _context.Gallery.FindAsync(id);
            if (item == null)
                return false;

            _context.Gallery.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
