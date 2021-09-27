using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class FixMenuFoodItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuFoodItem",
                table: "MenuFoodItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuFoodItem_MenuId",
                table: "MenuFoodItem");

            migrationBuilder.DropColumn(
                name: "MenuFoodItemId",
                table: "MenuFoodItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuFoodItem",
                table: "MenuFoodItem",
                columns: new[] { "MenuId", "FoodItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuFoodItem",
                table: "MenuFoodItem");

            migrationBuilder.DeleteData(
                table: "MenuFoodItem",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItem",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItem",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<int>(
                name: "MenuFoodItemId",
                table: "MenuFoodItem",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuFoodItem",
                table: "MenuFoodItem",
                column: "MenuFoodItemId");

            migrationBuilder.InsertData(
                table: "MenuFoodItem",
                columns: new[] { "MenuFoodItemId", "FoodItemId", "MenuId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "MenuFoodItem",
                columns: new[] { "MenuFoodItemId", "FoodItemId", "MenuId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "MenuFoodItem",
                columns: new[] { "MenuFoodItemId", "FoodItemId", "MenuId" },
                values: new object[] { 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItem_MenuId",
                table: "MenuFoodItem",
                column: "MenuId");
        }
    }
}
