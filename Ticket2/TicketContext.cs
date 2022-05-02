using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ticket2
{
    public partial class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Ticket;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Ticket_Number })
                    .HasName("segments_pkey");

                entity.ToTable("segments");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Ticket_Number).HasColumnName("ticket_number");

                entity.Property(e => e.Airline_Code)
                    .IsRequired()
                    .HasColumnName("airline_code");

                entity.Property(e => e.Arrive_Datetime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("arrive_datetime");

                entity.Property(e => e.Arrive_Place)
                    .IsRequired()
                    .HasColumnName("arrive_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Depart_Datetime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("depart_datetime");

                entity.Property(e => e.Depart_Place)
                    .IsRequired()
                    .HasColumnName("depart_place");

                entity.Property(e => e.Doc_Number).HasColumnName("doc_number");

                entity.Property(e => e.Doc_Type).HasColumnName("doc_type");

                entity.Property(e => e.Flight_Num).HasColumnName("flight_num");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Operation_Place)
                    .IsRequired()
                    .HasColumnName("operation_place");

                entity.Property(e => e.Operation_Type)
                    .IsRequired()
                    .HasColumnName("operation_type");

                entity.Property(e => e.Operration_Time)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("operration_time");

                entity.Property(e => e.Passenger_Type)
                    .IsRequired()
                    .HasColumnName("passenger_type");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnName("patronymic");

                entity.Property(e => e.Pnr_Id)
                    .IsRequired()
                    .HasColumnName("pnr_id");

                entity.Property(e => e.Refund).HasColumnName("refund");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname");

                entity.Property(e => e.Ticket_Type).HasColumnName("ticket_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
