using Domain.Abstractions;
using Domain.Entities;

namespace DatabaseMigration.Framework
{
    public abstract class SoftDeleteEntityMigration<TSofteleteEntity> : EntityMigration<TSofteleteEntity>
      where TSofteleteEntity : BaseEntity, ISoftDeletableEntity
    {
        public override void Up()
        {
            base.Up();

            Create.Column(nameof(ISoftDeletableEntity.IsDeleted)).OnTable(TableName)
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false)
                .Indexed();

            Create.Column(nameof(ISoftDeletableEntity.DeletedOn))
                .OnTable(TableName)
                .AsDateTime()
                .Nullable();

            Create.Column(nameof(ISoftDeletableEntity.DeletedReason))
                .OnTable(TableName)
                .AsString(int.MaxValue)
                .Nullable();

            CreateForeignKeyNullableColumn<User>(nameof(ISoftDeletableEntity.DeletedByUserId));
        }

        public override void Down()
        {
            DeleteForeignKeyColumn<User>(nameof(ISoftDeletableEntity.DeletedByUserId));
        }
    }
}
