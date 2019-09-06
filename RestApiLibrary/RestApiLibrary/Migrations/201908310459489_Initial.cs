namespace RestApiLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Author",
                c => new
                    {
                        AuthorlId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                        CountryId = c.String(maxLength: 5, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AuthorlId)                
                .ForeignKey("Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "Country",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Name = c.String(maxLength: 100, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CountryId)                ;
            
            CreateTable(
                "Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CategoryId)                ;
            
            CreateTable(
                "Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        ImagenPath = c.String(maxLength: 250, storeType: "nvarchar"),
                        PdfPath = c.String(maxLength: 250, storeType: "nvarchar"),
                        Private = c.Int(nullable: false),
                        OwnerId = c.String(maxLength: 45, storeType: "nvarchar"),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        EditorialId = c.Int(nullable: false),
                        PublicationDate = c.DateTime(nullable: false, precision: 0),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DocumentId)                
                .ForeignKey("Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("Editorial", t => t.EditorialId, cascadeDelete: true)
                .ForeignKey("SystemUser", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.EditorialId);
            
            CreateTable(
                "Editorial",
                c => new
                    {
                        EditorialId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                        CountryId = c.String(maxLength: 5, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.EditorialId)                
                .ForeignKey("Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "SystemUser",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                        Password = c.String(maxLength: 45, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        Telephone = c.String(maxLength: 50, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId)                ;
            
            CreateTable(
                "Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.LanguageId)                ;
            
            CreateTable(
                "SystemPermissions",
                c => new
                    {
                        PermissionsId = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.PermissionsId)                ;
            
            CreateTable(
                "SystemRol",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RoleId)                ;
            
            CreateTable(
                "SystemRolePermission",
                c => new
                    {
                        RolId = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        PermissionsId = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.RolId, t.PermissionsId })                
                .ForeignKey("SystemPermissions", t => t.PermissionsId, cascadeDelete: true)
                .ForeignKey("SystemRol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId)
                .Index(t => t.PermissionsId);
            
            CreateTable(
                "SystemUserRol",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        RolId = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        State = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                        ModifiedOn = c.DateTime(nullable: false, precision: 0),
                        ModifiedUser = c.String(maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RolId })                
                .ForeignKey("SystemRol", t => t.RolId, cascadeDelete: true)
                .ForeignKey("SystemUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SystemUserRol", "UserId", "SystemUser");
            DropForeignKey("SystemUserRol", "RolId", "SystemRol");
            DropForeignKey("SystemRolePermission", "RolId", "SystemRol");
            DropForeignKey("SystemRolePermission", "PermissionsId", "SystemPermissions");
            DropForeignKey("Document", "OwnerId", "SystemUser");
            DropForeignKey("Document", "EditorialId", "Editorial");
            DropForeignKey("Editorial", "CountryId", "Country");
            DropForeignKey("Document", "CategoryId", "Category");
            DropForeignKey("Document", "AuthorId", "Author");
            DropForeignKey("Author", "CountryId", "Country");
            DropIndex("SystemUserRol", new[] { "RolId" });
            DropIndex("SystemUserRol", new[] { "UserId" });
            DropIndex("SystemRolePermission", new[] { "PermissionsId" });
            DropIndex("SystemRolePermission", new[] { "RolId" });
            DropIndex("Editorial", new[] { "CountryId" });
            DropIndex("Document", new[] { "EditorialId" });
            DropIndex("Document", new[] { "AuthorId" });
            DropIndex("Document", new[] { "CategoryId" });
            DropIndex("Document", new[] { "OwnerId" });
            DropIndex("Author", new[] { "CountryId" });
            DropTable("SystemUserRol");
            DropTable("SystemRolePermission");
            DropTable("SystemRol");
            DropTable("SystemPermissions");
            DropTable("Language");
            DropTable("SystemUser");
            DropTable("Editorial");
            DropTable("Document");
            DropTable("Category");
            DropTable("Country");
            DropTable("Author");
        }
    }
}
