using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Migrations
{
    [DbContext(typeof(InfoContext))]
    [Migration("11102021103600_InitionalMigration")]
    internal class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Customers", 
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),

                }, constraints: consts =>
                {
                    consts.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: false),

                }, constraints: consts =>
                {
                    consts.PrimaryKey("PK_PhoneNumbers", x => x.PhoneId);
                });
        }
    }
}
