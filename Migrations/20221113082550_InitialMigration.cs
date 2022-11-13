using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryControl.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstSatuan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSatuan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstUnitOrg",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstUnitOrg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    SatuanId = table.Column<Guid>(nullable: false),
                    Stok = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MST_ITEM_MST_SATUAN",
                        column: x => x.SatuanId,
                        principalTable: "MstSatuan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestHeader",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REQUEST_HEADER_MST_STATUS",
                        column: x => x.StatusId,
                        principalTable: "MstStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MstUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    NIP = table.Column<string>(nullable: true),
                    KdOrg = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MST_USER_MST_UNIT_ORG",
                        column: x => x.KdOrg,
                        principalTable: "MstUnitOrg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequestHeaderId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    Jumlah = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REQUEST_ITEM_MST_ITEM",
                        column: x => x.ItemId,
                        principalTable: "MstItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REQUEST_ITEM_REQUEST_HEADER",
                        column: x => x.RequestHeaderId,
                        principalTable: "RequestHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MstItem_Id",
                table: "MstItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MstItem_SatuanId",
                table: "MstItem",
                column: "SatuanId");

            migrationBuilder.CreateIndex(
                name: "IX_MstSatuan_Id",
                table: "MstSatuan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MstStatus_Id",
                table: "MstStatus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MstUnitOrg_Id",
                table: "MstUnitOrg",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MstUser_Id",
                table: "MstUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MstUser_KdOrg",
                table: "MstUser",
                column: "KdOrg");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeader_Id",
                table: "RequestHeader",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeader_StatusId",
                table: "RequestHeader",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItem_Id",
                table: "RequestItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItem_ItemId",
                table: "RequestItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItem_RequestHeaderId",
                table: "RequestItem",
                column: "RequestHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstUser");

            migrationBuilder.DropTable(
                name: "RequestItem");

            migrationBuilder.DropTable(
                name: "MstUnitOrg");

            migrationBuilder.DropTable(
                name: "MstItem");

            migrationBuilder.DropTable(
                name: "RequestHeader");

            migrationBuilder.DropTable(
                name: "MstSatuan");

            migrationBuilder.DropTable(
                name: "MstStatus");
        }
    }
}
