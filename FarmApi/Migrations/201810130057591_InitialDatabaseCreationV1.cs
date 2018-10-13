namespace FarmApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreationV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalModels",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalNameOrTag = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateAcquired = c.DateTime(nullable: false),
                        AnimalType = c.String(),
                        Breed = c.String(),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        MedicalId = c.Int(nullable: false, identity: true),
                        VaccinationDescription = c.String(),
                        VaccinationDate = c.DateTime(nullable: false),
                        Dosage = c.String(),
                        Fk_Animal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicalId)
                .ForeignKey("dbo.AnimalModels", t => t.Fk_Animal_Id, cascadeDelete: true)
                .Index(t => t.Fk_Animal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "Fk_Animal_Id", "dbo.AnimalModels");
            DropIndex("dbo.MedicalRecords", new[] { "Fk_Animal_Id" });
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.AnimalModels");
        }
    }
}
