namespace RoomQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseNumber = c.String(maxLength: 32, unicode: false),
                        CourseName = c.String(maxLength: 128, unicode: false),
                        Professor_ProfessorID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Professors", t => t.Professor_ProfessorID)
                .Index(t => t.CourseNumber, unique: true)
                .Index(t => t.Professor_ProfessorID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Nuid = c.String(maxLength: 16, unicode: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        InSRC = c.Boolean(nullable: false),
                        IsTA = c.Boolean(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            CreateTable(
                "dbo.OfficeHours",
                c => new
                    {
                        OfficeHourID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Course_CourseID = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.OfficeHourID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false, identity: true),
                        Nuid = c.String(maxLength: 16, unicode: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SRCTimestamps",
                c => new
                    {
                        TimeStampID = c.Int(nullable: false, identity: true),
                        WasCheckIn = c.Boolean(nullable: false),
                        Stamp = c.DateTime(nullable: false),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.TimeStampID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SRCTimestamps", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Courses", "Professor_ProfessorID", "dbo.Professors");
            DropForeignKey("dbo.OfficeHours", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.OfficeHours", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Students", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SRCTimestamps", new[] { "Student_StudentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OfficeHours", new[] { "Student_StudentID" });
            DropIndex("dbo.OfficeHours", new[] { "Course_CourseID" });
            DropIndex("dbo.Students", new[] { "Course_CourseID" });
            DropIndex("dbo.Courses", new[] { "Professor_ProfessorID" });
            DropIndex("dbo.Courses", new[] { "CourseNumber" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SRCTimestamps");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Professors");
            DropTable("dbo.OfficeHours");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
