using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NGPD.Manager.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingdisponibilidadetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disponibilidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntervaloTempo_DiaSemana_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervaloTempo_DiaSemana_Id = table.Column<int>(type: "int", nullable: false),
                    IntervaloTempo_From = table.Column<TimeSpan>(type: "time", nullable: false),
                    IntervaloTempo_To = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidade", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilidade");
        }
    }
}
