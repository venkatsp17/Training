using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorClinicAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Age", "Experience", "LicenseNumber", "Name", "PhoneNumber", "Qualification", "Specialization" },
                values: new object[] { 1, 45, 12, "ABC123", "John", "3322445566", "MD", "ORTHO" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Age", "Experience", "LicenseNumber", "Name", "PhoneNumber", "Qualification", "Specialization" },
                values: new object[] { 2, 40, 7, "DEF456", "WicK", "1234567890", "MBBS", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
