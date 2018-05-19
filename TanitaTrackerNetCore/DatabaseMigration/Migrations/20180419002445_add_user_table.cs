using DatabaseMigration.Framework;
using Domain.Entities;
using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(20180419002445)]
    public class _20180419002445_add_user_table : SoftDeleteEntityMigration<User>
    {
        public override void Up()
        {
            base.Up();
            CreateColumnOnTable(nameof(Entity.Age)).AsInt32().WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.FirstName)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.LastName)).AsAnsiString().Nullable();
            CreateColumnOnTable(nameof(Entity.Height)).AsDouble().WithDefaultValue(0);
        }
    }
}