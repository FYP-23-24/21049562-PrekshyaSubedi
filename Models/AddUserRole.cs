namespace MitraNepAdven.Models
{
    public class AddUserRole
    {
        public int UserId { get; set; }
        public required List<int> RoleIds { get; set; }


    }
}
