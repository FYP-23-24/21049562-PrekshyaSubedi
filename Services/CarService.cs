using Microsoft.EntityFrameworkCore;
using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;

namespace MitraNepAdven.Services
{
    public class CarService: ICarService
    {
        private readonly JwtContext _context;

        public CarService(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            var addedCar = _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return addedCar.Entity;
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null)
                return false;

            existingCar.Name = car.Name;
            existingCar.CarType = car.CarType;

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
