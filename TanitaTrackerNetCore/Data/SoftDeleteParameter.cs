namespace Data
{
    public class SoftDeleteParameter
    {
        public int Id { get; set; }
        public int DeletedByUserId { get; set; }
        public string Reason { get; set; }
    }
}