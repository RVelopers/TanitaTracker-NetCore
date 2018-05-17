using System;

namespace Web_NetCore.Models
{
    /// <sumary>
    /// Base class for all extends all system entities.
    /// </sumary>
    public abstract class BaseEntity
    {
        /// <sumary>
        /// Identity of unique identifier
        /// </sumary>
        public int Id { get; set; }

        /// <sumary>
        /// Date when rows was registered
        /// </sumary>
        public DateTime CreatedAt { get; set; }

        /// <sumary>
        /// Status identity
        /// </sumary>
        public bool IsActive { get; set; }

        /// <sumary>
        /// Soft delete.
        /// </sumary>
        public bool IsDeleted { get; set; }
    }
}