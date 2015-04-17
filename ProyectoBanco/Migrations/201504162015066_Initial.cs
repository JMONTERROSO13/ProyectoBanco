namespace ProyectoBanco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombreCuenta = c.String(maxLength: 10),
                        TipoID = c.Int(nullable: false),
                        saldo = c.Int(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        TipoCuenta_IdTipo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCuentas", t => t.TipoCuenta_IdTipo)
                .Index(t => t.PersonaId)
                .Index(t => t.TipoCuenta_IdTipo);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dpi = c.String(nullable: false, maxLength: 13),
                        Nombre = c.String(maxLength: 60),
                        Email = c.String(nullable: false),
                        Apellido = c.String(maxLength: 60),
                        direccion = c.String(maxLength: 200),
                        telefono = c.String(maxLength: 10),
                        Referencia1 = c.String(maxLength: 100),
                        TelefonoReferencia1 = c.String(maxLength: 10),
                        Referencia2 = c.String(maxLength: 100),
                        TelefonoReferencia2 = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCuentas",
                c => new
                    {
                        IdTipo = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.IdTipo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        IdPersona = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Persona_Id", "dbo.Personas");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cuentas", "TipoCuenta_IdTipo", "dbo.TipoCuentas");
            DropForeignKey("dbo.Cuentas", "PersonaId", "dbo.Personas");
            DropIndex("dbo.AspNetUsers", new[] { "Persona_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Cuentas", new[] { "TipoCuenta_IdTipo" });
            DropIndex("dbo.Cuentas", new[] { "PersonaId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoCuentas");
            DropTable("dbo.Personas");
            DropTable("dbo.Cuentas");
        }
    }
}
