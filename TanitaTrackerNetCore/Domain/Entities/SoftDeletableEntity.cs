using System;
using Domain.Abstractions;

namespace Domain.Entities
{
    public class SoftDeletableEntity : BaseEntity, ISoftDeletableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedReason { get; set; }
        public User DeletedByUser { get; set; }
        public int? DeletedByUserId { get; set; }
    }
}