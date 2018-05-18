using System;
using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ISoftDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        string DeletedReason { get; set; }
        User DeletedByUser{ get; set; }
        int? DeletedByUserId { get; set; }
    }
}
