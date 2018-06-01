using DatabaseMigration.Framework;
using Domain.Entities;
using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(20180531201800)]
    public class _20180531201800_create_roles_table : SoftDeleteEntityMigration<Roles>
    {
        public override void Up()
        {
            base.Up();
            CreateColumnOnTable(nameof(Entity.Name)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.Description)).AsAnsiString().Nullable();
        }
    }
}