﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tryProject.Data;

namespace tryProject.Migrations
{
    [DbContext(typeof(tryProjectContext))]
    [Migration("20210521092119_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssociationCommunityWorks", b =>
                {
                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<int>("CommunityWorksId")
                        .HasColumnType("int");

                    b.HasKey("AssociationId", "CommunityWorksId");

                    b.HasIndex("CommunityWorksId");

                    b.ToTable("AssociationCommunityWorks");
                });

            modelBuilder.Entity("AssociationPurpose", b =>
                {
                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<int>("PurposesId")
                        .HasColumnType("int");

                    b.HasKey("AssociationId", "PurposesId");

                    b.HasIndex("PurposesId");

                    b.ToTable("AssociationPurpose");
                });

            modelBuilder.Entity("tryProject.Models.Association", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Association");
                });

            modelBuilder.Entity("tryProject.Models.CommunityWorks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Decscription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CommunityWorks");
                });

            modelBuilder.Entity("tryProject.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociationId")
                        .IsUnique();

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("tryProject.Models.MoneyDonation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PurposeId")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurposeId");

                    b.ToTable("MoneyDonation");
                });

            modelBuilder.Entity("tryProject.Models.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Purpose");
                });

            modelBuilder.Entity("tryProject.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("Volunteer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AssociationCommunityWorks", b =>
                {
                    b.HasOne("tryProject.Models.Association", null)
                        .WithMany()
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tryProject.Models.CommunityWorks", null)
                        .WithMany()
                        .HasForeignKey("CommunityWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssociationPurpose", b =>
                {
                    b.HasOne("tryProject.Models.Association", null)
                        .WithMany()
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tryProject.Models.Purpose", null)
                        .WithMany()
                        .HasForeignKey("PurposesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tryProject.Models.Manager", b =>
                {
                    b.HasOne("tryProject.Models.Association", "Association")
                        .WithOne("Manager")
                        .HasForeignKey("tryProject.Models.Manager", "AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Association");
                });

            modelBuilder.Entity("tryProject.Models.MoneyDonation", b =>
                {
                    b.HasOne("tryProject.Models.Purpose", "Purpose")
                        .WithMany("MoneyDonation")
                        .HasForeignKey("PurposeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purpose");
                });

            modelBuilder.Entity("tryProject.Models.Association", b =>
                {
                    b.Navigation("Manager")
                        .IsRequired();
                });

            modelBuilder.Entity("tryProject.Models.Purpose", b =>
                {
                    b.Navigation("MoneyDonation");
                });
#pragma warning restore 612, 618
        }
    }
}
