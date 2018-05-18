using System;
using Domain.Entities;
using FluentMigrator;
using FluentMigrator.Builders.Create.Column;
namespace DatabaseMigrations.Framework
{
        public abstract class EntityMigration<TEntity> : Migration where TEntity : BaseEntity
        {
            protected string TableName { get; set; }
            protected string KeyId => nameof(Entity.Id);
            protected TEntity Entity { get; set; }

            protected EntityMigration()
            {
                TableName = Pluralizer.Pluralize<TEntity>();
            }

            protected void CreateNameColumn(string columnName = "Name")
            {
                Create.Column(columnName).OnTable(TableName).AsString(200).NotNullable();
            }

            protected void CreateForeignKeyColumn<TEntityTable>(string columnName)
            where TEntityTable : BaseEntity
            {
                ValidateFkColumnName(columnName);

                Create.Column(columnName)
                 .OnTable(TableName)
                 .AsInt32()
                 .ForeignKey(Pluralizer.Pluralize<TEntityTable>(), KeyId).NotNullable().Indexed();
            }

            protected void CreateForeignKeyColumn<TEntityTable>(string columnName, object defaultValue)
            where TEntityTable : BaseEntity
            {
                ValidateFkColumnName(columnName);

                Create.Column(columnName)
                    .OnTable(TableName)
                    .AsInt32()
                    .ForeignKey(Pluralizer.Pluralize<TEntityTable>(), KeyId).NotNullable().Indexed().WithDefaultValue(defaultValue);
            }

            protected void CreateForeignKeyNullableColumn<TEntityTable>(string columnName)
            where TEntityTable : BaseEntity
            {
                ValidateFkColumnName(columnName);

                Create.Column(columnName)
                 .OnTable(TableName)
                 .AsInt32()
                 .ForeignKey(Pluralizer.Pluralize<TEntityTable>(), KeyId).Nullable().Indexed();
            }

            protected void DeleteForeignKeyColumn<TEntityTable>(string columnName)
            where TEntityTable : BaseEntity
            {
                ValidateFkColumnName(columnName);

                Delete.ForeignKey()
                   .FromTable(TableName)
                   .ForeignColumn(columnName)
                   .ToTable(Pluralizer.Pluralize<TEntityTable>())
                   .PrimaryColumn(KeyId);

                Delete.Index().OnTable(TableName).OnColumn(columnName);
            }

            protected ICreateColumnAsTypeOrInSchemaSyntax CreateColumnOnTable(string columnName)
            {
                return Create.Column(columnName).OnTable(TableName);
            }

            protected virtual void SeedData() { }

            public override void Up()
            {
                Create.Table(TableName)
                    .WithColumn(nameof(Entity.Id)).AsInt32().PrimaryKey().Identity()
                    .WithColumn(nameof(Entity.CreatedAt)).AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow);

                Create.Column(nameof(Entity.CreatedByUserId))
                    .OnTable(TableName)
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey(Pluralizer.Pluralize<User>(), nameof(User.Id))
                    .Indexed()
                    .WithDefaultValue(1);

                Create.Column(nameof(Entity.IsActive))
                    .OnTable(TableName)
                    .AsBoolean()
                    .NotNullable()
                    .WithDefaultValue(true)
                    .Indexed();
            }

            public override void Down()
            {
                DeleteForeignKeyColumn<User>(nameof(Entity.CreatedByUserId));

                Delete.Table(TableName);
            }

            public void ValidateFkColumnName(string fkColumnName)
            {
                if (!fkColumnName.ToUpper().Contains("Id".ToUpper()))
                    throw new Exception($"El nombre de la FK no contiene la frase [Id]. columName : {fkColumnName}");
            }
        }

}
