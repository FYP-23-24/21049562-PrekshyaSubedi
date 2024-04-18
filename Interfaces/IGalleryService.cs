using MitraNepAdven.Models;

namespace MitraNepAdven.Interfaces
{
    public interface IGalleryService
    {
        Task<List<Gallery>> GetAllGalleryAsync();
        Task<Gallery> GetGalleryByIdAsync(int id);
        Task<Gallery> AddGalleryAsync(Gallery gal);
        Task<bool> UpdateGalleryAsync(int id, Gallery gal);
        Task<bool> DeleteGalleryAsync(int id);
    }
}
