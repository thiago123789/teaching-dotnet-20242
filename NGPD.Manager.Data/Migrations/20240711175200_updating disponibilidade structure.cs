using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NGPD.Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatingdisponibilidadestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DisponibilidadeId",
                table: "MentorDisponibilidade",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MentorId",
                table: "MentorDisponibilidade",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Aluno",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisponibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisponibilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisponibilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmaDisponibilidade_Disponibilidade_DisponibilidadeId",
                        column: x => x.DisponibilidadeId,
                        principalTable: "Disponibilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaDisponibilidade_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorDisponibilidade_DisponibilidadeId",
                table: "MentorDisponibilidade",
                column: "DisponibilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorDisponibilidade_MentorId",
                table: "MentorDisponibilidade",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisponibilidade_DisponibilidadeId",
                table: "TurmaDisponibilidade",
                column: "DisponibilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisponibilidade_TurmaId",
                table: "TurmaDisponibilidade",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "MentorDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisponibilidade_Mentor_MentorId",
                table: "MentorDisponibilidade",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisponibilidade_Mentor_MentorId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "TurmaDisponibilidade");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_MentorDisponibilidade_DisponibilidadeId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropIndex(
                name: "IX_MentorDisponibilidade_MentorId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "DisponibilidadeId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Aluno");
        }
    }
}
