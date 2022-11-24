using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BachTX9_MiniProject_API.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: true),
                    Scores = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    QuesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    QuesBody = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.QuesId);
                    table.ForeignKey(
                        name: "FK_questions_tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userTests",
                columns: table => new
                {
                    UserTestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    Scores = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTests", x => x.UserTestId);
                    table.ForeignKey(
                        name: "FK_UserTest_Test",
                        column: x => x.TestId,
                        principalTable: "tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_User",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    AnsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuesId = table.Column<int>(nullable: false),
                    AnsBody = table.Column<string>(nullable: true),
                    IsTrue = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.AnsId);
                    table.ForeignKey(
                        name: "FK_answers_questions_QuesId",
                        column: x => x.QuesId,
                        principalTable: "questions",
                        principalColumn: "QuesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tests",
                columns: new[] { "TestId", "Description", "Duration", "Scores", "TestName" },
                values: new object[,]
                {
                    { 1, "Bai kiem tra 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Final C#" },
                    { 2, "Bai kiem tra 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Final Sql" },
                    { 3, "Bai kiem tra 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Final Web Api" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "Password", "PasswordHash", "PasswordSalt", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, " n@gmail.com", "123456", null, null, 0, false, "admin" },
                    { 2, " n@gmail.com", "123456", null, null, 1, false, "teacherA" },
                    { 3, " n@gmail.com", "123456", null, null, 2, false, "studentA" }
                });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "QuesId", "ImgUrl", "QuesBody", "TestId" },
                values: new object[,]
                {
                    { 1, "", "1 + 1", 1 },
                    { 2, "", "1 + 2", 2 },
                    { 3, "", "1 + 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "userTests",
                columns: new[] { "UserTestId", "CreateDate", "IsComplete", "Scores", "TestId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 2, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "answers",
                columns: new[] { "AnsId", "AnsBody", "ImgUrl", "IsTrue", "QuesId" },
                values: new object[,]
                {
                    { 1, "1", "", 1, 1 },
                    { 2, "2", "", 0, 1 },
                    { 3, "3", "", 0, 1 },
                    { 4, "4", "", 1, 1 },
                    { 5, "1", "", 0, 2 },
                    { 6, "2", "", 1, 2 },
                    { 7, "3", "", 0, 2 },
                    { 8, "4", "", 1, 2 },
                    { 9, "1", "", 1, 3 },
                    { 10, "2", "", 0, 3 },
                    { 11, "3", "", 0, 3 },
                    { 12, "4", "", 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_QuesId",
                table: "answers",
                column: "QuesId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_TestId",
                table: "questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_userTests_TestId",
                table: "userTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_userTests_UserId",
                table: "userTests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "userTests");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "tests");
        }
    }
}
