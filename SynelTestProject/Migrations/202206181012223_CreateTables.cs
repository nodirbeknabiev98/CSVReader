namespace SynelTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayrollNumber = c.String(),
                        Forenames = c.String(),
                        Surename = c.String(),
                        Date_of_Birth = c.DateTime(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        Address = c.String(),
                        Address_2 = c.String(),
                        PostCode = c.String(),
                        EMail_Home = c.String(),
                        Start_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeModels");
        }
    }
}
