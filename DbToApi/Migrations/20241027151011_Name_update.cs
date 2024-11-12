using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdToDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Name_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentsId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupsId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectsId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "SubjectsTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Marks_StudentsId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "Students",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SubjectsId",
                table: "Students",
                newName: "IX_Students_SubjectId");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "Marks",
                newName: "MarkNum");

            migrationBuilder.RenameColumn(
                name: "MarksId",
                table: "Marks",
                newName: "MarkId");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "Groups",
                newName: "GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherLastName",
                table: "Teachers",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherFirstName",
                table: "Teachers",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Subjects",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentLastName",
                table: "Students",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentFirstName",
                table: "Students",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsSubjectId = table.Column<int>(type: "int", nullable: false),
                    TeachersTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsSubjectId, x.TeachersTeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsSubjectId",
                        column: x => x.SubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersTeacherId",
                        column: x => x.TeachersTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersTeacherId",
                table: "SubjectTeacher",
                column: "TeachersTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Marks_StudentId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Students",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SubjectId",
                table: "Students",
                newName: "IX_Students_SubjectsId");

            migrationBuilder.RenameColumn(
                name: "MarkNum",
                table: "Marks",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "Marks",
                newName: "MarksId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Groups",
                newName: "GroupsId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherLastName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherFirstName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentLastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentFirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<int>(
                name: "GroupsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.CreateTable(
                name: "SubjectsTeachers",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsTeachers", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "TeachersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupsId",
                table: "Students",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentsId",
                table: "Marks",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsTeachers_TeachersId",
                table: "SubjectsTeachers",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentsId",
                table: "Marks",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupsId",
                table: "Students",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectsId",
                table: "Students",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "SubjectsId");
        }
    }
}
