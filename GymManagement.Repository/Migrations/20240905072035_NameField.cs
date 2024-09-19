using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerName",
                table: "Slots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerName",
                table: "Slots");
        }
    }
}
