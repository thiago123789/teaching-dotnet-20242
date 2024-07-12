using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NGPD.Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingdisponbilidaderelationsandsomeothertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
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
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorDisponibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorDisponibilidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SquadDisponibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisponibilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadDisponibilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadDisponibilidade_Disponibilidade_DisponibilidadeId",
                        column: x => x.DisponibilidadeId,
                        principalTable: "Disponibilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadDisponibilidade_Squad_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SquadDisponibilidade_DisponibilidadeId",
                table: "SquadDisponibilidade",
                column: "DisponibilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadDisponibilidade_SquadId",
                table: "SquadDisponibilidade",
                column: "SquadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "MentorDisponibilidade");

            migrationBuilder.DropTable(
                name: "SquadDisponibilidade");

            migrationBuilder.DropTable(
                name: "Squad");
        }
    }
}
