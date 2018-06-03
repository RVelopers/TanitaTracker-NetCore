namespace Domain.Entities
{
    public class Grant : SoftDeletableEntity
    {
        public Roles RoleId { get; set; }
        public Module ModuleId { get; set; }
        public string Method { get; set; }
    }
}