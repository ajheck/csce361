namespace RoomQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStudentID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Nuid", c => c.String(maxLength: 16, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Nuid");
        }
    }
}
