namespace ConstructionFinancial.DataEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedDate = c.String(),
                        ModifiedDate = c.String(),
                        GroupName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedDate = c.String(),
                        ModifiedDate = c.String(),
                        AccountName = c.String(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        Description = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountGroup", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateBirth = c.DateTime(nullable: false),
                        JobTitle = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralJournal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        Description = c.String(),
                        PostingReference = c.String(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPosted = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralLedger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        PostingReference = c.String(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPosted = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeEmployment = c.String(),
                        Password = c.String(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        ProjectManager = c.String(nullable: false, maxLength: 70),
                        SubProjectOf = c.Int(nullable: false),
                        ProjectTypeId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectType", t => t.ProjectTypeId, cascadeDelete: true)
                .Index(t => t.ProjectTypeId);
            
            CreateTable(
                "dbo.ProjectType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeNmae = c.String(nullable: false),
                        Description = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        SatrtDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false),
                        Description = c.String(),
                        Priority = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        BoQAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrialBalance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        AccountName = c.String(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDebit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItem", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Project", "ProjectTypeId", "dbo.ProjectType");
            DropForeignKey("dbo.ProjectMember", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Account", "GroupId", "dbo.AccountGroup");
            DropIndex("dbo.WorkItem", new[] { "TaskId" });
            DropIndex("dbo.Project", new[] { "ProjectTypeId" });
            DropIndex("dbo.ProjectMember", new[] { "Employee_Id" });
            DropIndex("dbo.Account", new[] { "GroupId" });
            DropTable("dbo.TrialBalance");
            DropTable("dbo.Task");
            DropTable("dbo.WorkItem");
            DropTable("dbo.ProjectType");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectMember");
            DropTable("dbo.GeneralLedger");
            DropTable("dbo.GeneralJournal");
            DropTable("dbo.Employee");
            DropTable("dbo.Account");
            DropTable("dbo.AccountGroup");
        }
    }
}
