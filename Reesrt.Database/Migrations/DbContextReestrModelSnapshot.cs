﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reestr.Database.Context;

namespace Reestr.Database.Migrations
{
    [DbContext(typeof(DbContextReestr))]
    partial class DbContextReestrModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reestr.Database.Model.AddressType", b =>
                {
                    b.Property<int>("IdAddressType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAddressType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdAddressType");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("Reestr.Database.Model.Addressing", b =>
                {
                    b.Property<int>("IdAddressing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("AddressingMapId")
                        .HasColumnType("int");

                    b.Property<int?>("DistrictsId")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Frame")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Letter")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PostcodeId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetsId")
                        .HasColumnType("int");

                    b.HasKey("IdAddressing");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("DistrictsId");

                    b.HasIndex("PostcodeId");

                    b.HasIndex("StreetsId");

                    b.ToTable("Addressings");
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

                    b.HasIndex("AddressingId");

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

                    b.ToTable("PhotographicFixation");
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

            modelBuilder.Entity("Reestr.Database.Model.Postcode", b =>
                {
                    b.Property<int>("IdPostcode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Csode")
                        .HasColumnType("int");

                    b.HasKey("IdPostcode");

                    b.ToTable("Postcodes");
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

                    b.Property<int?>("AddressingId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingTypeId")
                        .HasColumnType("int");

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

                    b.HasKey("IdRegisterOfEmergencyBuildings");

                    b.HasIndex("AddressingId");

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

            modelBuilder.Entity("Reestr.Database.Model.Streets", b =>
                {
                    b.Property<int>("IdStreets")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameStreetsRu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameStreetsUa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SolutionId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("StreetCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetsMapId")
                        .HasColumnType("int");

                    b.HasKey("IdStreets");

                    b.HasIndex("SolutionId");

                    b.HasIndex("StreetCategoryId");

                    b.ToTable("Streets");
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

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Url")
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)");

                    b.HasKey("IdUrbanPlanningConditions");

                    b.HasIndex("AddressingId");

                    b.HasIndex("LandId");

                    b.ToTable("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.Addressing", b =>
                {
                    b.HasOne("Reestr.Database.Model.AddressType", "AddressType")
                        .WithMany("Addressings")
                        .HasForeignKey("AddressTypeId");

                    b.HasOne("Reestr.Database.Model.Districts", "Districts")
                        .WithMany("Addressings")
                        .HasForeignKey("DistrictsId");

                    b.HasOne("Reestr.Database.Model.Postcode", "Postcode")
                        .WithMany("Addressings")
                        .HasForeignKey("PostcodeId");

                    b.HasOne("Reestr.Database.Model.Streets", "Streets")
                        .WithMany("Addressings")
                        .HasForeignKey("StreetsId");

                    b.Navigation("AddressType");

                    b.Navigation("Districts");

                    b.Navigation("Postcode");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Reestr.Database.Model.ConstructionPassport", b =>
                {
                    b.HasOne("Reestr.Database.Model.Addressing", "Addressing")
                        .WithMany("ConstructionPassport")
                        .HasForeignKey("AddressingId");

                    b.HasOne("Reestr.Database.Model.Land", "Land")
                        .WithMany("ConstructionPassport")
                        .HasForeignKey("LandId");

                    b.Navigation("Addressing");

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
                    b.HasOne("Reestr.Database.Model.Addressing", "Addressing")
                        .WithMany("ProjectArchive")
                        .HasForeignKey("AddressingId");

                    b.Navigation("Addressing");
                });

            modelBuilder.Entity("Reestr.Database.Model.RegisterOfEmergencyBuildings", b =>
                {
                    b.HasOne("Reestr.Database.Model.Addressing", "Addressing")
                        .WithMany("RegisterOfEmergencyBuildings")
                        .HasForeignKey("AddressingId");

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

                    b.Navigation("Addressing");

                    b.Navigation("BuildingType");

                    b.Navigation("Microdistrict");

                    b.Navigation("PossibilityOfReconstruction");

                    b.Navigation("TypeOfOwnership");
                });

            modelBuilder.Entity("Reestr.Database.Model.Streets", b =>
                {
                    b.HasOne("Reestr.Database.Model.Solution", "Solution")
                        .WithMany("Streets")
                        .HasForeignKey("SolutionId");

                    b.HasOne("Reestr.Database.Model.StreetCategory", "StreetCategory")
                        .WithMany("Streets")
                        .HasForeignKey("StreetCategoryId");

                    b.Navigation("Solution");

                    b.Navigation("StreetCategory");
                });

            modelBuilder.Entity("Reestr.Database.Model.UrbanPlanningConditions", b =>
                {
                    b.HasOne("Reestr.Database.Model.Addressing", "Addressing")
                        .WithMany("UrbanPlanningConditions")
                        .HasForeignKey("AddressingId");

                    b.HasOne("Reestr.Database.Model.Land", "Land")
                        .WithMany("UrbanPlanningConditions")
                        .HasForeignKey("LandId");

                    b.Navigation("Addressing");

                    b.Navigation("Land");
                });

            modelBuilder.Entity("Reestr.Database.Model.AddressType", b =>
                {
                    b.Navigation("Addressings");
                });

            modelBuilder.Entity("Reestr.Database.Model.Addressing", b =>
                {
                    b.Navigation("ConstructionPassport");

                    b.Navigation("ProjectArchive");

                    b.Navigation("RegisterOfEmergencyBuildings");

                    b.Navigation("UrbanPlanningConditions");
                });

            modelBuilder.Entity("Reestr.Database.Model.BuildingType", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });

            modelBuilder.Entity("Reestr.Database.Model.Districts", b =>
                {
                    b.Navigation("Addressings");
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

            modelBuilder.Entity("Reestr.Database.Model.Postcode", b =>
                {
                    b.Navigation("Addressings");
                });

            modelBuilder.Entity("Reestr.Database.Model.RegisterOfEmergencyBuildings", b =>
                {
                    b.Navigation("PhotographicFixation");
                });

            modelBuilder.Entity("Reestr.Database.Model.Solution", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Reestr.Database.Model.StreetCategory", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Reestr.Database.Model.Streets", b =>
                {
                    b.Navigation("Addressings");
                });

            modelBuilder.Entity("Reestr.Database.Model.TargetLand", b =>
                {
                    b.Navigation("Lands");
                });

            modelBuilder.Entity("Reestr.Database.Model.TypeOfOwnership", b =>
                {
                    b.Navigation("RegisterOfEmergencyBuildings");
                });
#pragma warning restore 612, 618
        }
    }
}
