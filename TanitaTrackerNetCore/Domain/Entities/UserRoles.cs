namespace Domain.Entities
{
    public class UserRoles : BaseEntity
    {
        public User UserId { get; set; }
        public Roles RoleId { get; set; }
    }
}