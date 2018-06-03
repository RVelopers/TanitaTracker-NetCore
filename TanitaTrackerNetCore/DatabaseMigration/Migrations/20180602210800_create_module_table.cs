using FluentMigrator;
using Domain.Entities;
using DatabaseMigration.Framework;

namespace DatabaseMigration.Migrations
{
    [Migration(20180602210800)]
    public class _20180602210800_create_module_table : SoftDeleteEntityMigration<Module>
    {
        public override void Up()
        {
            base.Up();
            CreateColumnOnTable(nameof(Entity.Name)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.Description)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.Controller)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.ActionCreate)).AsBoolean().WithDefaultValue(false);
            CreateColumnOnTable(nameof(Entity.ActionView)).AsBoolean().WithDefaultValue(false);
            CreateColumnOnTable(nameof(Entity.ActionEdit)).AsBoolean().WithDefaultValue(false);
            CreateColumnOnTable(nameof(Entity.ActionDelete)).AsBoolean().WithDefaultValue(false);
        }
    }
}