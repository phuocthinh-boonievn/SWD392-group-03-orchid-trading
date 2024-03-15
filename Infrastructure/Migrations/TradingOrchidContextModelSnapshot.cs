﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TradingOrchidContext))]
    partial class TradingOrchidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Aution", b =>
                {
                    b.Property<int>("AutionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutionID"));

                    b.Property<string>("AutionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AutionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<float>("MaxBid")
                        .HasColumnType("real");

                    b.Property<float>("StartingBid")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AutionID");

                    b.ToTable("Autions");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<string>("CommentMsg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InformationID")
                        .HasColumnType("int");

                    b.Property<bool>("IsCheckBool")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("InformationID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Information", b =>
                {
                    b.Property<int>("InformationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InformationID"));

                    b.Property<int?>("AutionID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InformationCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InformationTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrchidID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InformationID");

                    b.HasIndex("AutionID");

                    b.HasIndex("OrchidID");

                    b.HasIndex("UserID");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("Domain.Entities.OrchidProduct", b =>
                {
                    b.Property<int>("OrchidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrchidID"));

                    b.Property<string>("Characteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrchidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("OrchidID");

                    b.ToTable("OrchidProducts");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int?>("AutionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("AutionID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"));

                    b.Property<int?>("OrchidID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quanlity")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrchidID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Entities.RegisterAuction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BidID")
                        .HasColumnType("int");

                    b.Property<float>("Deposit")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BidID");

                    b.HasIndex("UserID");

                    b.ToTable("RegisterAuctions");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Customer"
                        },
                        new
                        {
                            RoleID = 4,
                            RoleName = "Manager"
                        },
                        new
                        {
                            RoleID = 5,
                            RoleName = "Orchid Owner"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int?>("OrderDetailID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("OrderDetailID");

                    b.HasIndex("UserID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varbinary(1024)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varbinary(1024)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("WalletBalance")
                        .HasColumnType("real");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "admin@gmail.com",
                            PasswordHash = new byte[] { 165, 235, 173, 10, 164, 116, 7, 196, 59, 24, 160, 114, 195, 11, 93, 153, 34, 53, 59, 241, 90, 235, 88, 0, 220, 144, 95, 102, 47, 64, 108, 172, 127, 85, 113, 170, 162, 26, 247, 136, 45, 67, 186, 75, 42, 204, 250, 10, 203, 53, 150, 124, 67, 60, 91, 97, 242, 247, 73, 38, 189, 37, 152, 136 },
                            PasswordSalt = new byte[] { 13, 128, 170, 189, 37, 175, 27, 99, 64, 114, 44, 222, 7, 60, 117, 36, 23, 77, 25, 44, 6, 14, 128, 204, 66, 20, 15, 113, 8, 17, 137, 136, 107, 8, 208, 155, 190, 248, 130, 121, 188, 110, 69, 195, 88, 7, 216, 179, 76, 145, 243, 145, 147, 255, 98, 66, 198, 34, 89, 47, 17, 60, 115, 89, 76, 155, 118, 229, 240, 133, 159, 121, 196, 75, 42, 249, 6, 104, 129, 166, 219, 211, 94, 19, 227, 71, 172, 41, 123, 57, 249, 195, 185, 166, 177, 63, 235, 146, 127, 251, 235, 105, 157, 254, 224, 6, 90, 207, 52, 123, 208, 168, 240, 198, 5, 24, 95, 119, 191, 165, 183, 115, 213, 182, 120, 58, 36, 68 },
                            RoleID = 1,
                            Status = true,
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Admin",
                            WalletBalance = 0f
                        },
                        new
                        {
                            UserID = 2,
                            Email = "staff@gmail.com",
                            PasswordHash = new byte[] { 235, 229, 69, 205, 199, 159, 193, 149, 39, 30, 232, 206, 224, 52, 38, 74, 90, 214, 65, 144, 115, 59, 105, 116, 255, 78, 61, 13, 58, 30, 212, 115, 120, 240, 42, 10, 187, 192, 178, 92, 184, 179, 129, 207, 219, 144, 102, 17, 181, 31, 69, 188, 80, 214, 111, 19, 178, 72, 69, 152, 0, 91, 231, 179 },
                            PasswordSalt = new byte[] { 104, 181, 30, 219, 129, 89, 8, 99, 15, 198, 196, 215, 133, 71, 10, 226, 55, 106, 48, 226, 164, 176, 52, 65, 19, 74, 22, 166, 96, 80, 71, 58, 215, 234, 46, 104, 70, 158, 10, 198, 125, 151, 231, 36, 0, 122, 200, 149, 41, 193, 229, 175, 220, 241, 56, 59, 30, 19, 120, 38, 37, 207, 40, 78, 139, 0, 3, 181, 67, 232, 73, 165, 217, 92, 107, 109, 232, 13, 218, 199, 140, 124, 194, 45, 20, 190, 87, 101, 234, 41, 92, 33, 232, 179, 127, 6, 31, 150, 208, 218, 36, 78, 92, 171, 194, 13, 255, 215, 249, 15, 187, 178, 147, 53, 5, 24, 248, 94, 107, 3, 251, 210, 177, 77, 242, 29, 27, 93 },
                            RoleID = 2,
                            Status = true,
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Staff",
                            WalletBalance = 0f
                        },
                        new
                        {
                            UserID = 3,
                            Email = "customer@gmail.com",
                            PasswordHash = new byte[] { 18, 246, 188, 216, 120, 178, 26, 66, 20, 154, 183, 208, 37, 168, 210, 70, 179, 117, 245, 130, 99, 115, 189, 18, 222, 253, 57, 50, 40, 172, 111, 191, 80, 15, 74, 162, 138, 192, 13, 246, 74, 231, 215, 154, 209, 246, 72, 90, 227, 71, 10, 68, 222, 185, 1, 42, 153, 197, 42, 60, 43, 155, 216, 224 },
                            PasswordSalt = new byte[] { 248, 54, 8, 191, 5, 214, 173, 169, 156, 101, 173, 60, 126, 71, 176, 89, 165, 58, 190, 167, 28, 136, 105, 252, 42, 154, 53, 48, 222, 73, 13, 144, 13, 136, 69, 128, 164, 213, 221, 229, 131, 147, 196, 103, 55, 20, 67, 186, 232, 110, 58, 167, 212, 75, 253, 137, 180, 37, 180, 210, 151, 177, 210, 116, 212, 83, 28, 49, 106, 16, 81, 195, 155, 12, 54, 110, 86, 255, 236, 202, 196, 90, 201, 248, 14, 232, 7, 169, 139, 237, 204, 187, 45, 191, 245, 36, 77, 197, 244, 165, 21, 240, 4, 211, 161, 121, 88, 165, 119, 249, 255, 168, 93, 2, 67, 184, 240, 93, 103, 212, 12, 26, 142, 227, 49, 162, 104, 255 },
                            RoleID = 3,
                            Status = true,
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Customer",
                            WalletBalance = 0f
                        },
                        new
                        {
                            UserID = 4,
                            Email = "manager@gmail.com",
                            PasswordHash = new byte[] { 53, 121, 31, 225, 94, 165, 64, 108, 227, 149, 33, 115, 108, 240, 72, 5, 109, 244, 54, 181, 140, 247, 4, 11, 51, 36, 24, 189, 15, 38, 251, 144, 178, 70, 196, 130, 119, 36, 65, 42, 20, 242, 17, 66, 67, 83, 33, 48, 64, 60, 102, 166, 109, 132, 106, 237, 172, 217, 243, 178, 200, 39, 115, 164 },
                            PasswordSalt = new byte[] { 97, 96, 94, 93, 155, 68, 50, 46, 75, 114, 240, 1, 223, 203, 180, 179, 114, 2, 133, 175, 201, 27, 10, 233, 84, 155, 101, 122, 76, 196, 168, 103, 163, 197, 56, 54, 120, 23, 195, 25, 77, 34, 69, 168, 142, 231, 102, 29, 15, 119, 85, 170, 152, 143, 158, 203, 123, 191, 253, 49, 246, 81, 255, 227, 19, 253, 217, 91, 12, 23, 212, 146, 42, 97, 252, 111, 248, 196, 197, 113, 97, 82, 165, 185, 241, 180, 253, 155, 21, 95, 216, 8, 186, 137, 50, 115, 110, 85, 216, 230, 126, 9, 192, 36, 231, 114, 197, 194, 1, 76, 166, 103, 53, 11, 119, 90, 149, 131, 238, 249, 156, 122, 68, 21, 147, 16, 205, 184 },
                            RoleID = 4,
                            Status = true,
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Manager",
                            WalletBalance = 0f
                        },
                        new
                        {
                            UserID = 5,
                            Email = "orchidowner@gmail.com",
                            PasswordHash = new byte[] { 236, 84, 95, 48, 224, 141, 103, 93, 175, 86, 19, 227, 174, 237, 182, 235, 134, 174, 40, 195, 202, 107, 161, 204, 189, 50, 238, 40, 33, 107, 132, 204, 63, 72, 6, 147, 151, 209, 173, 32, 42, 100, 204, 24, 192, 193, 232, 232, 33, 89, 12, 148, 3, 80, 236, 66, 35, 95, 120, 33, 150, 128, 234, 156 },
                            PasswordSalt = new byte[] { 70, 29, 92, 127, 224, 111, 70, 137, 150, 232, 141, 68, 36, 60, 195, 8, 245, 201, 106, 130, 5, 223, 185, 7, 233, 21, 185, 41, 237, 124, 130, 17, 19, 119, 176, 215, 112, 150, 224, 25, 20, 96, 47, 192, 252, 51, 188, 232, 101, 121, 16, 46, 122, 114, 239, 242, 217, 140, 95, 48, 242, 164, 151, 207, 166, 181, 154, 131, 143, 240, 184, 190, 150, 221, 150, 173, 250, 75, 132, 18, 213, 178, 47, 41, 138, 183, 138, 44, 7, 64, 71, 101, 212, 17, 224, 180, 44, 216, 69, 216, 247, 20, 6, 22, 92, 149, 212, 12, 120, 154, 197, 228, 85, 50, 168, 182, 43, 251, 204, 57, 210, 194, 50, 229, 56, 60, 29, 5 },
                            RoleID = 5,
                            Status = true,
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Orchid Owner",
                            WalletBalance = 0f
                        });
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Information", "Information")
                        .WithMany("Comments")
                        .HasForeignKey("InformationID");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Information");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Information", b =>
                {
                    b.HasOne("Domain.Entities.Aution", "Aution")
                        .WithMany()
                        .HasForeignKey("AutionID");

                    b.HasOne("Domain.Entities.OrchidProduct", "OrchidProduct")
                        .WithMany()
                        .HasForeignKey("OrchidID");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Informations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Aution");

                    b.Navigation("OrchidProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Aution", "Aution")
                        .WithMany()
                        .HasForeignKey("AutionID");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Aution");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Domain.Entities.OrchidProduct", "OrchidProduct")
                        .WithMany()
                        .HasForeignKey("OrchidID");

                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.Navigation("OrchidProduct");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Entities.RegisterAuction", b =>
                {
                    b.HasOne("Domain.Entities.Aution", "Aution")
                        .WithMany("RegisterAuctions")
                        .HasForeignKey("BidID");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RegisterAuctions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Aution");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.OrderDetail", "OrderDetail")
                        .WithMany()
                        .HasForeignKey("OrderDetailID");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("OrderDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Aution", b =>
                {
                    b.Navigation("RegisterAuctions");
                });

            modelBuilder.Entity("Domain.Entities.Information", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Informations");

                    b.Navigation("Orders");

                    b.Navigation("RegisterAuctions");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
