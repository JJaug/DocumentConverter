using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DocumentConverter.EF.Core.Models
{
    public partial class OrganizationsAndDocumentsContext : DbContext
    {
        public OrganizationsAndDocumentsContext()
        {
        }

        public OrganizationsAndDocumentsContext(DbContextOptions<OrganizationsAndDocumentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExportedDocument> ExportedDocuments { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LT-LIT-SC-0597\\MSSQLSERVER01; Initial Catalog=OrganizationsAndDocuments;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ExportedDocument>(entity =>
            {
                entity.Property(e => e.ExportedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.ExportedDocuments)
                    .HasForeignKey(d => d.FormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExportedD__Forma__2B3F6F97");
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.ToTable("Format");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ExportPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.FormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Organizat__Forma__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
