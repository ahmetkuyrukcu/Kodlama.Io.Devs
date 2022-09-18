using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.Io.Devs.Persistence.Migrations
{
    public partial class Added_Technology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("a134077b-b8fc-41f2-b2b2-ad69182a928d"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("f4e65afd-ddc9-4795-80e1-724847a2490b"));

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgrammingLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("477f1210-db3f-43fc-8403-cf018755aa41"), "C#" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e10194ea-85ec-4c51-a086-3ac7820f3594"), "Java" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { new Guid("35a5b5aa-f81a-4208-ad76-054a5bf58686"), ".NET", new Guid("477f1210-db3f-43fc-8403-cf018755aa41") });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { new Guid("37edf730-6ae7-4532-8233-138a1f5c9d0c"), "Spring", new Guid("e10194ea-85ec-4c51-a086-3ac7820f3594") });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { new Guid("b9516f6b-7cc5-4be3-8c11-f8e6e9e7754f"), "WPF", new Guid("477f1210-db3f-43fc-8403-cf018755aa41") });

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("477f1210-db3f-43fc-8403-cf018755aa41"));

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("e10194ea-85ec-4c51-a086-3ac7820f3594"));

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a134077b-b8fc-41f2-b2b2-ad69182a928d"), "C#" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f4e65afd-ddc9-4795-80e1-724847a2490b"), "Java" });
        }
    }
}
