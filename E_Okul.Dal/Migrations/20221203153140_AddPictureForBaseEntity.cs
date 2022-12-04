using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOkul.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureForBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Students");
        }
    }
}
