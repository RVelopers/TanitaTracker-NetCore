using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TanitaTrackerDatabase : ITanitaTrackerDatabase
    {
        #region Private Members
        
        private readonly TanitaTrackerDbContext _context;

        #endregion

        #region Constructor
        
        public TanitaTrackerDatabase(TanitaTrackerDbContext context)
        {
            _context = context;
        }

        #endregion


        public void Add<T>(T item) where T : class
        {
            Set<T>().Add(item);
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void SetModified<T>(T item) where T : class
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void SetDeleted<T>(T item) where T : class
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public void SoftDelete<T>(T item, SoftDeleteParameter deletedParameter) where T : SoftDeletableEntity
        {
            item.DeletedByUserId = deletedParameter.DeletedByUserId;
            item.DeletedOn   = DateTime.Now;
            item.DeletedReason      = deletedParameter.Reason;
            item.IsDeleted   = true;
            _context.Entry(item).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
    
    public interface ITanitaTrackerDatabase
    {
        void Add<T>(T item) where T : class;
        DbSet<T> Set<T>() where T : class;
        void SetModified<T>(T item) where T : class;
        void SetDeleted<T>(T item) where T : class;
        void SoftDelete<T>(T item, SoftDeleteParameter deletedParameter) where T : SoftDeletableEntity;
        int SaveChanges();
    }
}