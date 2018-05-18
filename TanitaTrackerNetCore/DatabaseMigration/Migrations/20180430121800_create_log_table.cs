using System;
using FluentMigrator;

namespace DatabaseMigrations.Migrations
{
    [Migration(20180430121800)]
    public class _20180430121800_create_log_table : Migration
    {
        
            public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
        
    }
}
