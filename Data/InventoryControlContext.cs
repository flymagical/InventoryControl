using InventoryControl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data
{
    public class InventoryControlContext : DbContext
    {

        public DbSet<MstUser> MstUser { get; set; }
        public DbSet<MstUnitOrg> MstUnitOrg { get; set; }
        public DbSet<MstSatuan> MstSatuan { get; set; }
        public DbSet<MstItem> MstItem { get; set; }
        public DbSet<MstStatus> MstStatus { get; set; }
        public DbSet<RequestHeader> RequestHeader { get; set; }
        public DbSet<RequestItem> RequestItem { get; set; }
        public InventoryControlContext()
        {

        }

        public InventoryControlContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MstUnitOrg>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);
            });

            modelBuilder.Entity<MstUser>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);

                entity.HasOne(x => x.MstUnitOrg)
                    .WithMany(x => x.MstUser)
                    .HasForeignKey(x => x.KdOrg)
                    .HasConstraintName("FK_MST_USER_MST_UNIT_ORG");
            });

            

            modelBuilder.Entity<MstItem>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);

                entity.HasOne(x => x.MstSatuan)
                    .WithMany(x => x.MstItem)
                    .HasForeignKey(x => x.SatuanId)
                    .HasConstraintName("FK_MST_ITEM_MST_SATUAN");
            });

            modelBuilder.Entity<MstSatuan>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);
            });

            modelBuilder.Entity<MstStatus>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);
            });

            modelBuilder.Entity<RequestHeader>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);

                entity.HasOne(x => x.MstStatus)
                    .WithMany(x => x.RequestHeader)
                    .HasForeignKey(x => x.StatusId)
                    .HasConstraintName("FK_REQUEST_HEADER_MST_STATUS");
            });

            modelBuilder.Entity<RequestItem>(entity => {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Id);

                entity.HasOne(x => x.RequestHeader)
                    .WithMany(x => x.RequestItem)
                    .HasForeignKey(x => x.RequestHeaderId)
                    .HasConstraintName("FK_REQUEST_ITEM_REQUEST_HEADER");

                entity.HasOne(x => x.MstItem)
                    .WithMany(x => x.RequestItem)
                    .HasConstraintName("FK_REQUEST_ITEM_MST_ITEM");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
               @"Server=DESKTOP-4THC5N4;Database=InventoryControl;Trusted_Connection=True;MultipleActive
ResultSets=true;", options => options.EnableRetryOnFailure());
            }
        }
    }
}
