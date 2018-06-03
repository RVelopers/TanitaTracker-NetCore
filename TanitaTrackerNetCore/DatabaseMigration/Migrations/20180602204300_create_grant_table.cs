using DatabaseMigration.Framework;
using Domain.Entities;
using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(20180602204300)]    
    public class _20180602204300_create_grant_table : SoftDeleteEntityMigration<Grant>
    {
        public override void Up()
        {
            base.Up();
            CreateForeignKeyColumn<Roles>(nameof(Entity.RoleId));
            CreateForeignKeyColumn<Module>(nameof(Entity.ModuleId));
            CreateColumnOnTable(nameof(Entity.Method)).AsAnsiString().Nullable();

        }
    }
}