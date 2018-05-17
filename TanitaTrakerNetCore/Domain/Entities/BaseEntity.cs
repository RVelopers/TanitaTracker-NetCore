﻿using System;
namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Domain.Entities.BaseEntity"/> is active.
        /// </summary>
        /// <value><c>true</c> if is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Domain.Entities.BaseEntity"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }
    }
}
