using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;

namespace MitraNepAdven.Services
{

    public class StaffService : IStaffService
    {
        private readonly JwtContext _context;
        public StaffService(JwtContext context)
        {
            _context = context;

        }
        public Staff AddStaff(Staff staff)
        {
            var stf = _context.Staff.Add(staff);
            _context.SaveChanges();
            return stf.Entity;
        }

        public List<Staff> GetStaffDetails()
        {
            var staffs = _context.Staff.ToList();
            return staffs;
        }
    }
}
