using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.Api.Common.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogCategories",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogCategories_CatalogCategories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "catalog",
                        principalTable: "CatalogCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                schema: "catalog",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    CatalogCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Medias = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Slug);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "catalog",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogCategories_CatalogCategoryId",
                        column: x => x.CatalogCategoryId,
                        principalSchema: "catalog",
                        principalTable: "CatalogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCategories_ParentId",
                schema: "catalog",
                table: "CatalogCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_BrandId",
                schema: "catalog",
                table: "CatalogItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogCategoryId",
                schema: "catalog",
                table: "CatalogItems",
                column: "CatalogCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogCategories",
                schema: "catalog");
        }
    }
}
