using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MitraNepAdven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/<StaffController>
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public List<Staff> GetStaff()
        {
            return _staffService.GetStaffDetails();
        }

        // POST api/<StaffController>
        [HttpPost]
        [Authorize]
        public Staff AddStaff([FromBody] Staff stf)
        {
            var staff = _staffService.AddStaff(stf);
            return staff;
        }


    }

}
