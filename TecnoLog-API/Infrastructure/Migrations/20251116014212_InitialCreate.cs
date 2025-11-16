using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_stock_department",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDepartment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_stock_subgroup",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSubgroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_unit_of_measurement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_department",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_stock_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    unit_of_measurement_id = table.Column<Guid>(type: "uuid", nullable: true),
                    localization = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    stock_department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    stock_group = table.Column<short>(type: "smallint", nullable: true),
                    stock_subgroup_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cost = table.Column<decimal>(type: "numeric", nullable: true),
                    minimum_stock = table.Column<short>(type: "smallint", nullable: true),
                    inbound = table.Column<long>(type: "bigint", nullable: false),
                    outbound = table.Column<long>(type: "bigint", nullable: false),
                    current = table.Column<long>(type: "bigint", nullable: false),
                    stock_situation = table.Column<short>(type: "smallint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_stock_item_tb_stock_department_stock_department_id",
                        column: x => x.stock_department_id,
                        principalTable: "tb_stock_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tb_stock_item_tb_stock_subgroup_stock_subgroup_id",
                        column: x => x.stock_subgroup_id,
                        principalTable: "tb_stock_subgroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tb_stock_item_tb_unit_of_measurement_unit_of_measurement_id",
                        column: x => x.unit_of_measurement_id,
                        principalTable: "tb_unit_of_measurement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    role = table.Column<short>(type: "smallint", nullable: false),
                    user_department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_user_tb_user_department_user_department_id",
                        column: x => x.user_department_id,
                        principalTable: "tb_user_department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_register",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    register_type = table.Column<short>(type: "smallint", nullable: false),
                    stock_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_register_tb_stock_item_stock_item_id",
                        column: x => x.stock_item_id,
                        principalTable: "tb_stock_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_register_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_register_stock_item_id",
                table: "tb_register",
                column: "stock_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_register_user_id",
                table: "tb_register",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stock_item_stock_department_id",
                table: "tb_stock_item",
                column: "stock_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stock_item_stock_subgroup_id",
                table: "tb_stock_item",
                column: "stock_subgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stock_item_unit_of_measurement_id",
                table: "tb_stock_item",
                column: "unit_of_measurement_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_user_department_id",
                table: "tb_user",
                column: "user_department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_register");

            migrationBuilder.DropTable(
                name: "tb_stock_item");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_stock_department");

            migrationBuilder.DropTable(
                name: "tb_stock_subgroup");

            migrationBuilder.DropTable(
                name: "tb_unit_of_measurement");

            migrationBuilder.DropTable(
                name: "tb_user_department");
        }
    }
}
