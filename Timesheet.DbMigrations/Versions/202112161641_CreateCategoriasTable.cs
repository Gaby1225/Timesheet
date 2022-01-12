using FluentMigrator;

namespace Timesheet.DbMigration.Versions
{
    [Migration(202112161641)]
    public class CreateCategoriasTable : Migration
    {
        public override void Up()
        {
            Create.Table("Categorias")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Titulo").AsAnsiString(100).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Categorias");
        }
    }
}

