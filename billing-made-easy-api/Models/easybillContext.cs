using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace billing_made_easy_api.Models
{
    public partial class easybillContext : DbContext
    {
        public easybillContext()
        {
        }

        public easybillContext(DbContextOptions<easybillContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<DeliveryDetails> DeliveryDetails { get; set; }
        public virtual DbSet<PartyDetails> PartyDetails { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<PaymentStatusMaster> PaymentStatusMaster { get; set; }
        public virtual DbSet<PaymentTypeMaster> PaymentTypeMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=PC_DEBOJYOTI\\SQLEXPRESS;Database=easy-bill;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasIndex(e => e.BillNumber)
                    .HasName("UQ__Bill__8C4311118D54FC88")
                    .IsUnique();

                entity.Property(e => e.BillDate)
                    .HasColumnName("billDate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BillNumber)
                    .HasColumnName("billNumber")
                    .HasMaxLength(30);

                entity.Property(e => e.BillTotalAmount)
                    .HasColumnName("billTotalAmount")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.BillTotalCgst)
                    .HasColumnName("billTotalCGST")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.BillTotalSgst)
                    .HasColumnName("billTotalSGST")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.BillTotalTax)
                    .HasColumnName("billTotalTax")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.BillType)
                    .HasColumnName("billType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BillerName)
                    .HasColumnName("billerName")
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefDeliveryId).HasColumnName("refDeliveryId");

                entity.Property(e => e.RefPartyId).HasColumnName("refPartyId");

                entity.Property(e => e.RefPaymentId).HasColumnName("refPaymentId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RefDelivery)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.RefDeliveryId)
                    .HasConstraintName("FK__Bill__refDeliver__04E4BC85");

                entity.HasOne(d => d.RefParty)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.RefPartyId)
                    .HasConstraintName("FK__Bill__refPartyId__06CD04F7");

                entity.HasOne(d => d.RefPayment)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.RefPaymentId)
                    .HasConstraintName("FK__Bill__refPayment__08B54D69");
            });

            modelBuilder.Entity<DeliveryDetails>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryAddress).HasColumnName("deliveryAddress");

                entity.Property(e => e.DeliveryCharge)
                    .HasColumnName("deliveryCharge")
                    .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("deliveryDate")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryMode)
                    .HasColumnName("deliveryMode")
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PartyDetails>(entity =>
            {
                entity.HasIndex(e => e.GstNumber)
                    .HasName("UQ__PartyDet__4FB704C4EAF3C911")
                    .IsUnique();

                entity.HasIndex(e => e.PanNumber)
                    .HasName("UQ__PartyDet__3DACD6BAC9376882")
                    .IsUnique();

                entity.Property(e => e.AddressLine)
                    .HasColumnName("addressLine")
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GstNumber)
                    .HasColumnName("gstNumber")
                    .HasMaxLength(30);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobileNumber")
                    .HasColumnType("numeric(12, 0)");

                entity.Property(e => e.PanNumber)
                    .HasColumnName("panNumber")
                    .HasMaxLength(12);

                entity.Property(e => e.PartyName).HasColumnName("partyName");

                entity.Property(e => e.StateInformation)
                    .HasColumnName("stateInformation")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.Property(e => e.BillAmount)
                    .HasColumnName("billAmount")
                    .HasColumnType("numeric(15, 3)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("paymentAmount")
                    .HasColumnType("numeric(15, 3)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("paymentDate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMode).HasColumnName("paymentMode");

                entity.Property(e => e.PaymentReferenceNumber)
                    .HasColumnName("paymentReferenceNumber")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.PaymentStatus).HasColumnName("paymentStatus");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("paymentType")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Expense')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PaymentModeNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentMode)
                    .HasConstraintName("FK__PaymentDe__payme__7B5B524B");

                entity.HasOne(d => d.PaymentStatusNavigation)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.PaymentStatus)
                    .HasConstraintName("FK__PaymentDe__payme__7C4F7684");
            });

            modelBuilder.Entity<PaymentStatusMaster>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("paymentStatus")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PaymentTypeMaster>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("paymentType")
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
