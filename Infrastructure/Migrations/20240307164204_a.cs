using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autions",
                columns: table => new
                {
                    AutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingBid = table.Column<float>(type: "real", nullable: false),
                    MaxBid = table.Column<float>(type: "real", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autions", x => x.AutionID);
                });

            migrationBuilder.CreateTable(
                name: "OrchidProducts",
                columns: table => new
                {
                    OrchidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrchidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrchidProducts", x => x.OrchidID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(1024)", maxLength: 1024, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(1024)", maxLength: 1024, nullable: false),
                    WalletBalance = table.Column<float>(type: "real", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    InformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InformationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InformationCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AutionID = table.Column<int>(type: "int", nullable: true),
                    OrchidID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.InformationID);
                    table.ForeignKey(
                        name: "FK_Informations_Autions_AutionID",
                        column: x => x.AutionID,
                        principalTable: "Autions",
                        principalColumn: "AutionID");
                    table.ForeignKey(
                        name: "FK_Informations_OrchidProducts_OrchidID",
                        column: x => x.OrchidID,
                        principalTable: "OrchidProducts",
                        principalColumn: "OrchidID");
                    table.ForeignKey(
                        name: "FK_Informations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AutionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Autions_AutionID",
                        column: x => x.AutionID,
                        principalTable: "Autions",
                        principalColumn: "AutionID");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterAuctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Deposit = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    BidID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterAuctions_Autions_BidID",
                        column: x => x.BidID,
                        principalTable: "Autions",
                        principalColumn: "AutionID");
                    table.ForeignKey(
                        name: "FK_RegisterAuctions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCheckBool = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    InformationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Informations_InformationID",
                        column: x => x.InformationID,
                        principalTable: "Informations",
                        principalColumn: "InformationID");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Quanlity = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    OrchidID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrchidProducts_OrchidID",
                        column: x => x.OrchidID,
                        principalTable: "OrchidProducts",
                        principalColumn: "OrchidID");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    OrderDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_OrderDetails_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Staff" },
                    { 3, "Customer" },
                    { 4, "Manager" },
                    { 5, "Orchid Owner" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "PasswordHash", "PasswordSalt", "Phone", "RoleID", "Status", "TokenExpires", "UserName", "WalletBalance" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", new byte[] { 165, 235, 173, 10, 164, 116, 7, 196, 59, 24, 160, 114, 195, 11, 93, 153, 34, 53, 59, 241, 90, 235, 88, 0, 220, 144, 95, 102, 47, 64, 108, 172, 127, 85, 113, 170, 162, 26, 247, 136, 45, 67, 186, 75, 42, 204, 250, 10, 203, 53, 150, 124, 67, 60, 91, 97, 242, 247, 73, 38, 189, 37, 152, 136 }, new byte[] { 13, 128, 170, 189, 37, 175, 27, 99, 64, 114, 44, 222, 7, 60, 117, 36, 23, 77, 25, 44, 6, 14, 128, 204, 66, 20, 15, 113, 8, 17, 137, 136, 107, 8, 208, 155, 190, 248, 130, 121, 188, 110, 69, 195, 88, 7, 216, 179, 76, 145, 243, 145, 147, 255, 98, 66, 198, 34, 89, 47, 17, 60, 115, 89, 76, 155, 118, 229, 240, 133, 159, 121, 196, 75, 42, 249, 6, 104, 129, 166, 219, 211, 94, 19, 227, 71, 172, 41, 123, 57, 249, 195, 185, 166, 177, 63, 235, 146, 127, 251, 235, 105, 157, 254, 224, 6, 90, 207, 52, 123, 208, 168, 240, 198, 5, 24, 95, 119, 191, 165, 183, 115, 213, 182, 120, 58, 36, 68 }, null, 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 0f },
                    { 2, "staff@gmail.com", new byte[] { 235, 229, 69, 205, 199, 159, 193, 149, 39, 30, 232, 206, 224, 52, 38, 74, 90, 214, 65, 144, 115, 59, 105, 116, 255, 78, 61, 13, 58, 30, 212, 115, 120, 240, 42, 10, 187, 192, 178, 92, 184, 179, 129, 207, 219, 144, 102, 17, 181, 31, 69, 188, 80, 214, 111, 19, 178, 72, 69, 152, 0, 91, 231, 179 }, new byte[] { 104, 181, 30, 219, 129, 89, 8, 99, 15, 198, 196, 215, 133, 71, 10, 226, 55, 106, 48, 226, 164, 176, 52, 65, 19, 74, 22, 166, 96, 80, 71, 58, 215, 234, 46, 104, 70, 158, 10, 198, 125, 151, 231, 36, 0, 122, 200, 149, 41, 193, 229, 175, 220, 241, 56, 59, 30, 19, 120, 38, 37, 207, 40, 78, 139, 0, 3, 181, 67, 232, 73, 165, 217, 92, 107, 109, 232, 13, 218, 199, 140, 124, 194, 45, 20, 190, 87, 101, 234, 41, 92, 33, 232, 179, 127, 6, 31, 150, 208, 218, 36, 78, 92, 171, 194, 13, 255, 215, 249, 15, 187, 178, 147, 53, 5, 24, 248, 94, 107, 3, 251, 210, 177, 77, 242, 29, 27, 93 }, null, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff", 0f },
                    { 3, "customer@gmail.com", new byte[] { 18, 246, 188, 216, 120, 178, 26, 66, 20, 154, 183, 208, 37, 168, 210, 70, 179, 117, 245, 130, 99, 115, 189, 18, 222, 253, 57, 50, 40, 172, 111, 191, 80, 15, 74, 162, 138, 192, 13, 246, 74, 231, 215, 154, 209, 246, 72, 90, 227, 71, 10, 68, 222, 185, 1, 42, 153, 197, 42, 60, 43, 155, 216, 224 }, new byte[] { 248, 54, 8, 191, 5, 214, 173, 169, 156, 101, 173, 60, 126, 71, 176, 89, 165, 58, 190, 167, 28, 136, 105, 252, 42, 154, 53, 48, 222, 73, 13, 144, 13, 136, 69, 128, 164, 213, 221, 229, 131, 147, 196, 103, 55, 20, 67, 186, 232, 110, 58, 167, 212, 75, 253, 137, 180, 37, 180, 210, 151, 177, 210, 116, 212, 83, 28, 49, 106, 16, 81, 195, 155, 12, 54, 110, 86, 255, 236, 202, 196, 90, 201, 248, 14, 232, 7, 169, 139, 237, 204, 187, 45, 191, 245, 36, 77, 197, 244, 165, 21, 240, 4, 211, 161, 121, 88, 165, 119, 249, 255, 168, 93, 2, 67, 184, 240, 93, 103, 212, 12, 26, 142, 227, 49, 162, 104, 255 }, null, 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", 0f },
                    { 4, "manager@gmail.com", new byte[] { 53, 121, 31, 225, 94, 165, 64, 108, 227, 149, 33, 115, 108, 240, 72, 5, 109, 244, 54, 181, 140, 247, 4, 11, 51, 36, 24, 189, 15, 38, 251, 144, 178, 70, 196, 130, 119, 36, 65, 42, 20, 242, 17, 66, 67, 83, 33, 48, 64, 60, 102, 166, 109, 132, 106, 237, 172, 217, 243, 178, 200, 39, 115, 164 }, new byte[] { 97, 96, 94, 93, 155, 68, 50, 46, 75, 114, 240, 1, 223, 203, 180, 179, 114, 2, 133, 175, 201, 27, 10, 233, 84, 155, 101, 122, 76, 196, 168, 103, 163, 197, 56, 54, 120, 23, 195, 25, 77, 34, 69, 168, 142, 231, 102, 29, 15, 119, 85, 170, 152, 143, 158, 203, 123, 191, 253, 49, 246, 81, 255, 227, 19, 253, 217, 91, 12, 23, 212, 146, 42, 97, 252, 111, 248, 196, 197, 113, 97, 82, 165, 185, 241, 180, 253, 155, 21, 95, 216, 8, 186, 137, 50, 115, 110, 85, 216, 230, 126, 9, 192, 36, 231, 114, 197, 194, 1, 76, 166, 103, 53, 11, 119, 90, 149, 131, 238, 249, 156, 122, 68, 21, 147, 16, 205, 184 }, null, 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", 0f },
                    { 5, "orchidowner@gmail.com", new byte[] { 236, 84, 95, 48, 224, 141, 103, 93, 175, 86, 19, 227, 174, 237, 182, 235, 134, 174, 40, 195, 202, 107, 161, 204, 189, 50, 238, 40, 33, 107, 132, 204, 63, 72, 6, 147, 151, 209, 173, 32, 42, 100, 204, 24, 192, 193, 232, 232, 33, 89, 12, 148, 3, 80, 236, 66, 35, 95, 120, 33, 150, 128, 234, 156 }, new byte[] { 70, 29, 92, 127, 224, 111, 70, 137, 150, 232, 141, 68, 36, 60, 195, 8, 245, 201, 106, 130, 5, 223, 185, 7, 233, 21, 185, 41, 237, 124, 130, 17, 19, 119, 176, 215, 112, 150, 224, 25, 20, 96, 47, 192, 252, 51, 188, 232, 101, 121, 16, 46, 122, 114, 239, 242, 217, 140, 95, 48, 242, 164, 151, 207, 166, 181, 154, 131, 143, 240, 184, 190, 150, 221, 150, 173, 250, 75, 132, 18, 213, 178, 47, 41, 138, 183, 138, 44, 7, 64, 71, 101, 212, 17, 224, 180, 44, 216, 69, 216, 247, 20, 6, 22, 92, 149, 212, 12, 120, 154, 197, 228, 85, 50, 168, 182, 43, 251, 204, 57, 210, 194, 50, 229, 56, 60, 29, 5 }, null, 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orchid Owner", 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InformationID",
                table: "Comments",
                column: "InformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_AutionID",
                table: "Informations",
                column: "AutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_OrchidID",
                table: "Informations",
                column: "OrchidID");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_UserID",
                table: "Informations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrchidID",
                table: "OrderDetails",
                column: "OrchidID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AutionID",
                table: "Orders",
                column: "AutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAuctions_BidID",
                table: "RegisterAuctions",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAuctions_UserID",
                table: "RegisterAuctions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderDetailID",
                table: "Transactions",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RegisterAuctions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrchidProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Autions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
