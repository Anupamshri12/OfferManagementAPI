using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiePayAssignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableOffer",
                columns: table => new
                {
                    adjustmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adjustmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adjustmentSubtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentInstrument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    banks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emiMonths = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableOffer", x => x.adjustmentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableOffer");
        }
    }
}
