using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NGPD.Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingfaculdadetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropForeignKey(
                name: "FK_SquadDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "SquadDisponibilidade");

            migrationBuilder.DropForeignKey(
                name: "FK_TurmaDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "TurmaDisponibilidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disponibilidade",
                table: "Disponibilidade");

            migrationBuilder.RenameTable(
                name: "Disponibilidade",
                newName: "Disponibilidades");

            migrationBuilder.AddColumn<Guid>(
                name: "FaculdadeId",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Squad",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MentorId",
                table: "Squad",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Squad",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Aluno",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disponibilidades",
                table: "Disponibilidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Faculdade",
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
                    table.PrimaryKey("PK_Faculdade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turma_FaculdadeId",
                table: "Turma",
                column: "FaculdadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_EmpresaId",
                table: "Squad",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_MentorId",
                table: "Squad",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_TurmaId",
                table: "Squad",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "MentorDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Empresa_EmpresaId",
                table: "Squad",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Mentor_MentorId",
                table: "Squad",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_Turma_TurmaId",
                table: "Squad",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SquadDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "SquadDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Faculdade_FaculdadeId",
                table: "Turma",
                column: "FaculdadeId",
                principalTable: "Faculdade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TurmaDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "TurmaDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidades",
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
                name: "FK_MentorDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "MentorDisponibilidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Empresa_EmpresaId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Mentor_MentorId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_Turma_TurmaId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_SquadDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "SquadDisponibilidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Faculdade_FaculdadeId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_TurmaDisponibilidade_Disponibilidades_DisponibilidadeId",
                table: "TurmaDisponibilidade");

            migrationBuilder.DropTable(
                name: "Faculdade");

            migrationBuilder.DropIndex(
                name: "IX_Turma_FaculdadeId",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Squad_EmpresaId",
                table: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Squad_MentorId",
                table: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Squad_TurmaId",
                table: "Squad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disponibilidades",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "FaculdadeId",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Squad");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Squad");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Squad");

            migrationBuilder.RenameTable(
                name: "Disponibilidades",
                newName: "Disponibilidade");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Aluno",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disponibilidade",
                table: "Disponibilidade",
                column: "Id");

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
                name: "FK_SquadDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "SquadDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TurmaDisponibilidade_Disponibilidade_DisponibilidadeId",
                table: "TurmaDisponibilidade",
                column: "DisponibilidadeId",
                principalTable: "Disponibilidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
