﻿using Microsoft.EntityFrameworkCore;
using Reestr.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Database.Context
{
    public class DbContextReestr : DbContext
    {
        public DbContextReestr(DbContextOptions<DbContextReestr> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Addressing> Addressings { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<ConstructionPassport> ConstructionPassports { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<PlotAssignment> PlotAssignments { get; set; }
        public DbSet<Postcode> Postcodes { get; set; }
        public DbSet<ProjectArchive> ProjectArchives { get; set; }
        public DbSet<RegisterOfEmergencyBuildings> RegisterOfEmergencyBuildings { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<StreetCategory> StreetCategories { get; set; }
        public DbSet<Streets> Streets { get; set; }
        public DbSet<TargetLand> targetLands { get; set; }
        public DbSet<UrbanPlanningConditions> UrbanPlanningConditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streets>(entity =>
            {
                entity.HasKey(h => h.IdStreets);
                entity.Property(p => p.NameStreetsRu).HasMaxLength(100);
                entity.Property(p => p.NameStreetsUa).HasMaxLength(100);
            });

            modelBuilder.Entity<Addressing>(entity =>
            {
                entity.HasKey(h => h.IdAddressing);
                entity.Property(p => p.Number).HasMaxLength(50);
                entity.Property(p => p.Frame).HasMaxLength(10);
                entity.Property(p => p.Letter).HasMaxLength(200);
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasKey(h => h.IdAddressType);
                entity.Property(p => p.NameAddressType).HasMaxLength(200);
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasKey(h => h.IdDistricts);
                entity.Property(p => p.NameDistricts).HasMaxLength(50);
            });

            modelBuilder.Entity<StreetCategory>(entity =>
            {
                entity.HasKey(h => h.IdStreetCategory);
                entity.Property(p => p.NameCategoryRu).HasMaxLength(50);
                entity.Property(p => p.NameCategoryUa).HasMaxLength(50);
                entity.Property(p => p.FullNameCategoryRu).HasMaxLength(100);
                entity.Property(p => p.FullNameCategoryUa).HasMaxLength(100);
            });

            modelBuilder.Entity<UrbanPlanningConditions>(entiti =>
            {
                entiti.HasKey(h => h.IdUrbanPlanningConditions);
                entiti.Property(p => p.OrderNumber).HasMaxLength(10);
                entiti.Property(p => p.AuthorityName).HasMaxLength(250);
                entiti.Property(p => p.ApplicantName).HasMaxLength(350);
                entiti.Property(p => p.Type).HasMaxLength(550);
                entiti.Property(p => p.Name).HasMaxLength(550);
                entiti.Property(p => p.Status).HasMaxLength(50);
                entiti.Property(p => p.CancellationDescription).HasMaxLength(550);
                entiti.Property(p => p.ChangesDescription).HasMaxLength(550);
                entiti.Property(p => p.Url).HasMaxLength(750);
            });

            modelBuilder.Entity<ConstructionPassport>(entiti =>
            {
                entiti.HasKey(h => h.IdConstructionPassport);
                entiti.Property(p => p.AuthorityName).HasMaxLength(250);
                entiti.Property(p => p.ApplicantName).HasMaxLength(350);
                entiti.Property(p => p.Type).HasMaxLength(550);
                entiti.Property(p => p.Name).HasMaxLength(550);
                entiti.Property(p => p.Status).HasMaxLength(50);
                entiti.Property(p => p.CancellationDescription).HasMaxLength(550);
                entiti.Property(p => p.ChangesDescription).HasMaxLength(550);
                entiti.Property(p => p.Url).HasMaxLength(750);
            });

            modelBuilder.Entity<ProjectArchive>(entiti =>
            {
                entiti.HasKey(h => h.IdProjectArchive);
                entiti.Property(p => p.Customer).HasMaxLength(300);
                entiti.Property(p => p.ProjectOrganization).HasMaxLength(400);
                entiti.Property(p => p.ProjectName).HasMaxLength(500);
            });

            modelBuilder.Entity<Land>(entiti =>
            {
                entiti.HasKey(h => h.IdLand);
                entiti.Property(p => p.CadastralNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<PlotAssignment>(entiti =>
            {
                entiti.HasKey(h => h.IdPlotAssignment);
                entiti.Property(p => p.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TargetLand>(entiti =>
            {
                entiti.HasKey(h => h.IdTargetLand);
                entiti.Property(p => p.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Postcode>(entiti =>
            {
                entiti.HasKey(h => h.IdPostcode);
            });

            modelBuilder.Entity<RegisterOfEmergencyBuildings>(entiti => 
            {
                entiti.HasKey(h => h.IdRegisterOfEmergencyBuildings);
                entiti.Property(p => p.TypeBuildings).HasMaxLength(300);
                entiti.Property(p => p.Description).HasMaxLength(1000);
                entiti.Property(p => p.TypeOfDestruction).HasMaxLength(100);
                entiti.Property(p => p.JobDescription).HasMaxLength(2000);
                entiti.Property(p => p.Note).HasMaxLength(2000);
            });

            modelBuilder.Entity<Solution>(entiti => 
            {
                entiti.HasKey(h => h.IdSolution);
                entiti.Property(p => p.DecisionNumber).HasMaxLength(20);
                entiti.Property(p => p.UrlSolution).HasMaxLength(500);
            });

            modelBuilder.Entity<Microdistrict>(entiti =>
            {
                entiti.HasKey(h => h.IdMicrodistrict);
                entiti.Property(h => h.NameMicrodistrict).HasMaxLength(200);
                entiti.Property(h => h.Note).HasMaxLength(2000);
            });

            modelBuilder.Entity<TypeOfOwnership>(entiti =>
            {
                entiti.HasKey(h => h.IdTypeOfOwnership);
                entiti.Property(h => h.NameTypeOfOwnership).HasMaxLength(200);
            });

            modelBuilder.Entity<BuildingType>(entiti => 
            {
                entiti.HasKey(h => h.IdBuildingType);
                entiti.Property(h => h.NameBuildingType).HasMaxLength(200);

            });

            modelBuilder.Entity<PhotographicFixation>(entiti =>
            {
                entiti.HasKey(h => h.IdPhotographicFixation);
                entiti.Property(h => h.Url).HasMaxLength(500);

            });

            modelBuilder.Entity<PossibilityOfReconstruction>(entiti =>
            {
                entiti.HasKey(h => h.IdPossibilityOfReconstruction);
                entiti.Property(h => h.ScanDoc).HasMaxLength(200);
            });
        }
    }
}
