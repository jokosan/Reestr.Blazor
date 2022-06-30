﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reestr.Database.Context;

namespace Reestr.Database.Migrations
{
    [DbContext(typeof(DbContextReestr))]
    [Migration("20220621155113_EditTableUrbanPlanningConditions")]
    partial class EditTableUrbanPlanningConditions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reestr.Database.Model.AddressingApi", b =>
                {
                    b.Property<int>("IdApiBuildings")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Detail")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("DetailNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DetailUa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("DistrictUa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdAddressingApi")
                        .HasColumnType("int");

                    b.Property<decimal?>("Lat")
                        .HasColumnType("decimal(18,10)");

                    b.Property<decimal?>("Longi")
                        .HasColumnType("decimal(18,10)");

                    b.Property<string>("NameUkr")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Postcode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SameAddrComm")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Streetid")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TypeUkr")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("IdApiBuildings");

                    b.ToTable("AddressingApi");
                });

            modelBuilder.Entity("Reestr.Database.Model.BuildingType", b =>
                {
                    b.Property<int>("IdBuildingType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameBuildingType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdBuildingType");

                    b.ToTable("BuildingType");
                });

            modelBuilder.Entity("Reestr.Database.Model.ConstructionPassport", b =>
                {
                    b.Property<int>("IdConstructionPassport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressingId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicantIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantName")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("AuthorityName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("AuthoritytIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("CancellationDescription")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("ChangesDescription")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<int?>("LandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<DateTime?>("OrderIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Url")
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.HasKey("IdConstructionPassport");

                    b.HasIndex("LandId");

                    b.ToTable("ConstructionPassports");
                });

            modelBuilder.Entity("Reestr.Database.Model.Districts", b =>
                {
                    b.Property<int>("IdDistricts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameDistricts")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDistricts");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Reestr.Database.Model.DocumentStatus", b =>
                {
                    b.Property<int>("IdDocumentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdDocumentStatus");

                    b.ToTable("DocumentStatus");
                });

            modelBuilder.Entity("Reestr.Database.Model.InfoUser", b =>
                {
                    b.Property<int>("IdInfoUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("InfoUserId")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PlaceOfWork")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Position")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdInfoUser");

                    b.ToTable("InfoUser");
                });

            modelBuilder.Entity("Reestr.Database.Model.Land", b =>
                {
                    b.Property<int>("IdLand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CadastralNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PlotAssignmentId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetLandId")
                        .HasColumnType("int");

                    b.HasKey("IdLand");

                    b.HasIndex("PlotAssignmentId");

                    b.HasIndex("TargetLandId");

                    b.ToTable("Lands");
                });

            modelBuilder.Entity("Reestr.Database.Model.Microdistrict", b =>
                {
                    b.Property<int>("IdMicrodistrict")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameMicrodistrict")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Note")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("IdMicrodistrict");

                    b.ToTable("Microdistrict");
                });

            modelBuilder.Entity("Reestr.Database.Model.PhotographicFixation", b =>
                {
                    b.Property<int>("IdPhotographicFixation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RegisterOfEmergencyBuildingsId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IdPhotographicFixation");

                    b.HasIndex("RegisterOfEmergencyBuildingsId");

                    b.ToTable("PhotographicFixations");
                });

            modelBuilder.Entity("Reestr.Database.Model.PlotAssignment", b =>
                {
                    b.Property<int>("IdPlotAssignment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdPlotAssignment");

                    b.ToTable("PlotAssignments");
                });

            modelBuilder.Entity("Reestr.Database.Model.PossibilityOfReconstruction", b =>
                {
                    b.Property<int>("IdPossibilityOfReconstruction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ScanDoc")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdPossibilityOfReconstruction");

                    b.ToTable("PossibilityOfReconstruction");
                });

            modelBuilder.Entity("Reestr.Database.Model.ProjectArchive", b =>
                {
                    b.Property<int>("IdProjectArchive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressingId")
                        .HasColumnType("int");

                    b.Property<string>("Customer")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ProjectNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProjectOrganization")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("VarianceApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdProjectArchive");

                    b.HasIndex("AddressingId");

                    b.ToTable("ProjectArchives");
                });

            modelBuilder.Entity("Reestr.Database.Model.RegisterOfEmergencyBuildings", b =>
                {
                    b.Property<int>("IdRegisterOfEmergencyBuildings")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressesApiId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DataSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateInsert")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("JobDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("MicrodistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("PhotographicFixationId")
                        .HasColumnType("int");

                    b.Property<int?>("PossibilityOfReconstructionId")
                        .HasColumnType("int");

                    b.Property<string>("SectorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeBuildings")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("TypeOfDestruction")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TypeOfOwnershipId")
                        .HasColumnType("int");

                    b.Property<string>("UserNameInsert")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserNameUpdate")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdRegisterOfEmergencyBuildings");

                    b.HasIndex("AddressesApiId");

                    b.HasIndex("BuildingTypeId");

                    b.HasIndex("MicrodistrictId");

                    b.HasIndex("PossibilityOfReconstructionId");

                    b.HasIndex("TypeOfOwnershipId");

                    b.ToTable("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.Solution", b =>
                {
                    b.Property<int>("IdSolution")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DecisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DecisionNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UrlSolution")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IdSolution");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("Reestr.Database.Model.StreetCategory", b =>
                {
                    b.Property<int>("IdStreetCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullNameCategoryRu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullNameCategoryUa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameCategoryRu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameCategoryUa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdStreetCategory");

                    b.ToTable("StreetCategories");
                });

            modelBuilder.Entity("Reestr.Database.Model.TargetLand", b =>
                {
                    b.Property<int>("IdTargetLand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdTargetLand");

                    b.ToTable("targetLands");
                });

            modelBuilder.Entity("Reestr.Database.Model.TypeOfConstruction", b =>
                {
                    b.Property<int>("IdTypeOfConstruction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdTypeOfConstruction");

                    b.ToTable("TypeOfConstruction");
                });

            modelBuilder.Entity("Reestr.Database.Model.TypeOfOwnership", b =>
                {
                    b.Property<int>("IdTypeOfOwnership")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameTypeOfOwnership")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdTypeOfOwnership");

                    b.ToTable("TypeOfOwnership");
                });

            modelBuilder.Entity("Reestr.Database.Model.UrbanPlanningConditions", b =>
                {
                    b.Property<int>("IdUrbanPlanningConditions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addressing")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int?>("AddressingId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicantIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("AuthorityName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("AuthoritytIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("CancellationDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ChangesDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("DocumentStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("LandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("OrderIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TypeOfConstructionId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.HasKey("IdUrbanPlanningConditions");

                    b.HasIndex("DocumentStatusId");

                    b.HasIndex("LandId");

                    b.HasIndex("TypeOfConstructionId");

                    b.ToTable("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.ConstructionPassport", b =>
                {
                    b.HasOne("Reestr.Database.Model.Land", "Land")
                        .WithMany("ConstructionPassport")
                        .HasForeignKey("LandId");

                    b.Navigation("Land");
                });

            modelBuilder.Entity("Reestr.Database.Model.Land", b =>
                {
                    b.HasOne("Reestr.Database.Model.PlotAssignment", "PlotAssignment")
                        .WithMany("Lands")
                        .HasForeignKey("PlotAssignmentId");

                    b.HasOne("Reestr.Database.Model.TargetLand", "TargetLand")
                        .WithMany("Lands")
                        .HasForeignKey("TargetLandId");

                    b.Navigation("PlotAssignment");

                    b.Navigation("TargetLand");
                });

            modelBuilder.Entity("Reestr.Database.Model.PhotographicFixation", b =>
                {
                    b.HasOne("Reestr.Database.Model.RegisterOfEmergencyBuildings", "RegisterOfEmergencyBuildings")
                        .WithMany("PhotographicFixation")
                        .HasForeignKey("RegisterOfEmergencyBuildingsId");

                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.ProjectArchive", b =>
                {
                    b.HasOne("Reestr.Database.Model.AddressingApi", "Addressing")
                        .WithMany()
                        .HasForeignKey("AddressingId");

                    b.Navigation("Addressing");
                });

            modelBuilder.Entity("Reestr.Database.Model.RegisterOfEmergencyBuildings", b =>
                {
                    b.HasOne("Reestr.Database.Model.AddressingApi", "AddressingApi")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("AddressesApiId")
                        .HasPrincipalKey("IdAddressingApi");

                    b.HasOne("Reestr.Database.Model.BuildingType", "BuildingType")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("BuildingTypeId");

                    b.HasOne("Reestr.Database.Model.Microdistrict", "Microdistrict")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("MicrodistrictId");

                    b.HasOne("Reestr.Database.Model.PossibilityOfReconstruction", "PossibilityOfReconstruction")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("PossibilityOfReconstructionId");

                    b.HasOne("Reestr.Database.Model.TypeOfOwnership", "TypeOfOwnership")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("TypeOfOwnershipId");

                    b.Navigation("AddressingApi");

                    b.Navigation("BuildingType");

                    b.Navigation("Microdistrict");

                    b.Navigation("PossibilityOfReconstruction");

                    b.Navigation("TypeOfOwnership");
                });

            modelBuilder.Entity("Reestr.Database.Model.UrbanPlanningConditions", b =>
                {
                    b.HasOne("Reestr.Database.Model.DocumentStatus", "DocumentStatus")
                        .WithMany("UrbanPlanningConditions")
                        .HasForeignKey("DocumentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reestr.Database.Model.Land", "Land")
                        .WithMany("UrbanPlanningConditions")
                        .HasForeignKey("LandId");

                    b.HasOne("Reestr.Database.Model.TypeOfConstruction", "TypeOfConstruction")
                        .WithMany("UrbanPlanningConditions")
                        .HasForeignKey("TypeOfConstructionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentStatus");

                    b.Navigation("Land");

                    b.Navigation("TypeOfConstruction");
                });

            modelBuilder.Entity("Reestr.Database.Model.AddressingApi", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.BuildingType", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.DocumentStatus", b =>
                {
                    b.Navigation("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.Land", b =>
                {
                    b.Navigation("ConstructionPassport");

                    b.Navigation("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.Microdistrict", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.PlotAssignment", b =>
                {
                    b.Navigation("Lands");
                });

            modelBuilder.Entity("Reestr.Database.Model.PossibilityOfReconstruction", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.RegisterOfEmergencyBuildings", b =>
                {
                    b.Navigation("PhotographicFixation");
                });

            modelBuilder.Entity("Reestr.Database.Model.TargetLand", b =>
                {
                    b.Navigation("Lands");
                });

            modelBuilder.Entity("Reestr.Database.Model.TypeOfConstruction", b =>
                {
                    b.Navigation("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.TypeOfOwnership", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });
#pragma warning restore 612, 618
        }
    }
}
