namespace RoomQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProfessor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professors", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professors", "Email");
        }
    }
}
