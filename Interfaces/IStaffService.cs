using MitraNepAdven.Models;

namespace MitraNepAdven.Interfaces
{
    public interface IStaffService
    {
        
        public List<Staff> GetStaffDetails();
        public Staff AddStaff(Staff staff);
    }
}

