using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentCoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FavoriteMajorCourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FavoriteElectiveCourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentProfileId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CourseCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    CompletionStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRecords_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "CollegeProgram", "FavoriteElectiveCourse", "FavoriteMajorCourse", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, "Information Technology", "Second-Year Japanese 1", "Programming II", "Joshua Hampton", "Sophomore" },
                    { 2, "Computer Science", "Basic French I", "Data Structures", "Alex Morgan", "Sophomore" },
                    { 3, "Economics", "Basic Spanish I", "Macroeconomics", "Taylor Reed", "Freshman" },
                    { 4, "Mathematics", "Japanese Pop, Anime, and Video Game Music", "Calculus III", "Jordan Blake", "Junior" },
                    { 5, "Nursing", "Introduction to Psychology", "Fundamentals of Patient Centered Care", "Casey Nguyen", "Sophomore" }
                });

            migrationBuilder.InsertData(
                table: "CourseRecords",
                columns: new[] { "Id", "CompletionStatus", "CourseCategory", "CourseCode", "CourseName", "CreditHours", "Semester", "StudentProfileId" },
                values: new object[,]
                {
                    { 1, "Completed", "Major", "IT-2045C", "Programming II", 3, "Spring 2025", 1 },
                    { 2, "Completed", "Major", "IT-3045C", "Client-Side Web Programming", 3, "Summer 2025", 1 },
                    { 3, "In Progress", "Major", "IT-2035C", "Network Infrastructure Management", 3, "Spring 2026", 1 },
                    { 4, "Planned", "Elective", "JAPN-2001", "Second-Year Japanese 1", 5, "Fall 2026", 1 },
                    { 5, "Completed", "Major", "CS-1021C", "Computer Science I", 3, "Fall 2025", 2 },
                    { 6, "Completed", "General Education", "MATH-1062", "Calculus II", 3, "Fall 2025", 2 },
                    { 7, "In Progress", "Major", "CS-2028C", "Data Structures", 3, "Spring 2026", 2 },
                    { 8, "In Progress", "Elective", "FREN-1001", "Basic French I", 5, "Spring 2026", 2 },
                    { 9, "Completed", "Major", "ECON-1001", "Introduction to Microeconomics", 3, "Fall 2025", 3 },
                    { 10, "In Progress", "Major", "ECON-1002", "Introduction to Macroeconomics", 3, "Spring 2026", 3 },
                    { 11, "In Progress", "Elective", "SPAN-1001", "Basic Spanish I", 5, "Spring 2026", 3 },
                    { 12, "Completed", "Major", "MATH-1062", "Calculus II", 4, "Spring 2025", 4 },
                    { 13, "Completed", "Major", "MATH-2063", "Multivariable Calculus", 4, "Fall 2025", 4 },
                    { 14, "Completed", "Elective", "FAM-2050", "Japanese Pop, Anime, and Video Game Music", 3, "Fall 2025", 4 },
                    { 15, "Completed", "Major", "NBSN-1101", "Introduction to Professional Nursing", 3, "Fall 2025", 5 },
                    { 16, "In Progress", "Major", "NBSN-2101C", "Fundamentals of Patient Centered Care", 6, "Spring 2026", 5 },
                    { 17, "Completed", "Elective", "PSY-1001", "Introduction to Psychology", 3, "Fall 2026", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseRecords_StudentProfileId",
                table: "CourseRecords",
                column: "StudentProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRecords");

            migrationBuilder.DropTable(
                name: "StudentProfiles");
        }
    }
}
