using DatabaseMigration.Framework;
using Domain.Entities;
using FluentMigrator;

namespace DatabaseMigration.Migrations
{    
    [Migration(20180531203000)]
    public class _20180531203000_create_users_roles_table : EntityMigration<UserRoles>
    {
        public override void Up()
        {
            base.Up();
            CreateForeignKeyColumn<User>(nameof(Entity.UserId));
            CreateForeignKeyColumn<Roles>(nameof(Entity.RoleId));
        }
    }
}