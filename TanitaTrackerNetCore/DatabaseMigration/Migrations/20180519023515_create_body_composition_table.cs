using DatabaseMigration.Framework;
using Domain.Entities;
using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(20180519023515)]
    public class _20180519023515_create_body_composition_table : SoftDeleteEntityMigration<BodyCompositionResult>
    {
        public override void Up()
        {
            base.Up();
            CreateForeignKeyColumn<User>(nameof(Entity.UserId));
            CreateColumnOnTable(nameof(Entity.Weight)).AsDecimal(3,2).WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.BMI)).AsDecimal(3,2).WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.BMILevel)).AsInt32().WithDefaultValue(1);
            CreateColumnOnTable(nameof(Entity.FatPercentage)).AsDecimal(3,2).WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.MusclePercentage)).AsDecimal(3,2).WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.ViceralFat)).AsInt32().WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.FatLevel)).AsInt32().WithDefaultValue(1);
            CreateColumnOnTable(nameof(Entity.MuscleLevel)).AsInt32().WithDefaultValue(1);
            CreateColumnOnTable(nameof(Entity.ViceralFatLevel)).AsInt32().WithDefaultValue(1);
            CreateColumnOnTable(nameof(Entity.RmKcal)).AsInt32().WithDefaultValue(0);
            CreateColumnOnTable(nameof(Entity.MetabolicAge)).AsInt32().WithDefaultValue(0);
        }
    }
}