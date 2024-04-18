using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitraNepAdven.Services
{
    public class PackageService : IPackageService
    {
        private readonly JwtContext _context;

        public PackageService(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetPackageByIdAsync(int id)
        {
            return await _context.Packages.FindAsync(id);
        }

        public async Task<Package> AddPackageAsync(Package package)
        {
            var addedPackage = _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return addedPackage.Entity;
        }

        public async Task<bool> UpdatePackageAsync(int id, Package package)
        {
            var existingPackage = await _context.Packages.FindAsync(id);
            if (existingPackage == null)
                return false;

            existingPackage.Title = package.Title;
            existingPackage.Duration = package.Duration;
            existingPackage.Description = package.Description;
            existingPackage.NumberOfPeople = package.NumberOfPeople;
            existingPackage.ImageUrl = package.ImageUrl;
            existingPackage.MapImageUrl = package.MapImageUrl;
            // Update other properties as needed

            _context.Packages.Update(existingPackage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
                return false;

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }

        public Package AddPackage(Package package)
        {
            throw new NotImplementedException();
        }
    }
}
