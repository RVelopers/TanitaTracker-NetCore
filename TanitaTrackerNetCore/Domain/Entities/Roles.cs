namespace Domain.Entities
{
    public class Roles : SoftDeletableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }    
    }
}