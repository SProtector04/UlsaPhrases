using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UlsaPhrases.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phrase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhraseStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhraseAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhraseDedication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhraseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhraseContext = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrase", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phrase");
        }
    }
}
