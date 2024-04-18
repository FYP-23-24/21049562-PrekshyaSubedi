using MitraNepAdven.Models;

namespace MitraNepAdven.Interfaces
{
    public interface IGearService
    {
        Task<List<Gear>> GetAllGearsAsync();
        Task<Gear> GetGearByIdAsync(int id);
        Task<Gear> AddGearAsync(Gear gear);
        Task<bool> UpdateGearAsync(int id, Gear gear);
        Task<bool> DeleteGearAsync(int id);
    }
}
