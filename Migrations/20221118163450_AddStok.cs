using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryControl.Migrations
{
    public partial class AddStok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stok",
                table: "MstItem");

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    Jumlah = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stok_MstItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "MstItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stok_ItemId",
                table: "Stok",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.AddColumn<int>(
                name: "Stok",
                table: "MstItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
