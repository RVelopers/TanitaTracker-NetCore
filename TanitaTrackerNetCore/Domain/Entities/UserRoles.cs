namespace Domain.Entities
{
    public class UserRoles : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}