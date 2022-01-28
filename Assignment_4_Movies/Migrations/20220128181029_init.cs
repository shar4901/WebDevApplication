using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDevApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    street_address = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    state = table.Column<string>(nullable: false),
                    zip = table.Column<int>(nullable: false),
                    phone_number = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "student_id", "category", "city", "email", "first_name", "last_name", "phone_number", "state", "street_address", "zip" },
                values: new object[] { 1, "full_time", "South Jordan", "test@test.com", "Spencer", "Harrison", "801-915-7986", "UT", "1466 11150 S", 84095 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
