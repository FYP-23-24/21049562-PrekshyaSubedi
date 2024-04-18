using MitraNepAdven.Models;
using System.Threading.Tasks;

namespace MitraNepAdven.Interfaces
{
    public interface IPackageService
    {
        Task<Package> GetPackageByIdAsync(int id);
        Task<Package> AddPackageAsync(Package package);
        Task<bool> UpdatePackageAsync(int id, Package package);
        Task<bool> DeletePackageAsync(int id);
    }
}
