namespace ASPNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_T_Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        Passwords = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.TB_M_Employee", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.TB_M_Employee",
                c => new
                    {
                        employeeId = c.Int(nullable: false, identity: true),
                        Nama = c.String(),
                        BirthDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        divisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employeeId)
                .ForeignKey("dbo.TB_M_Division", t => t.divisionId, cascadeDelete: true)
                .Index(t => t.divisionId);
            
            CreateTable(
                "dbo.TB_M_Division",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        NamaDivisi = c.String(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_Account", "AccountId", "dbo.TB_M_Employee");
            DropForeignKey("dbo.TB_M_Employee", "divisionId", "dbo.TB_M_Division");
            DropIndex("dbo.TB_M_Employee", new[] { "divisionId" });
            DropIndex("dbo.TB_T_Account", new[] { "AccountId" });
            DropTable("dbo.TB_M_Division");
            DropTable("dbo.TB_M_Employee");
            DropTable("dbo.TB_T_Account");
        }
    }
}
