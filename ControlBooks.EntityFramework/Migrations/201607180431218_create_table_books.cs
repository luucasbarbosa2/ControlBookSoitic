namespace ControlBooks.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 250),
                        Subtitulo = c.String(nullable: false, maxLength: 250),
                        Sinopse = c.String(nullable: false, maxLength: 250),
                        Ano = c.DateTime(nullable: false),
                        Volume = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Autor_Id = c.Guid(),
                        Publisher_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Book_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Book_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.Autor_Id)
                .ForeignKey("dbo.Publisher", t => t.Publisher_Id)
                .Index(t => t.Autor_Id)
                .Index(t => t.Publisher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Publisher_Id", "dbo.Publisher");
            DropForeignKey("dbo.Books", "Autor_Id", "dbo.Autor");
            DropIndex("dbo.Books", new[] { "Publisher_Id" });
            DropIndex("dbo.Books", new[] { "Autor_Id" });
            DropTable("dbo.Books",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Book_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Book_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
