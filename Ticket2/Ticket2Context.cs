using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ticket2
{
    public partial class Ticket2Context : DbContext
    {
        public Ticket2Context()
        {
        }

        public Ticket2Context(DbContextOptions<Ticket2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Ticket2;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasKey(e => new { e.SerialNumber, e.TicketNumber })
                    .HasName("segments_pkey");

                entity.ToTable("segments");

                entity.Property(e => e.SerialNumber).HasColumnName("serial_number");

                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");

                entity.Property(e => e.AirlineCode)
                    .IsRequired()
                    .HasColumnName("airline_code");

                entity.Property(e => e.ArriveDatetime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("arrive_datetime");

                entity.Property(e => e.ArrivePlace)
                    .IsRequired()
                    .HasColumnName("arrive_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.DepartDatetime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("depart_datetime");

                entity.Property(e => e.DepartPlace)
                    .IsRequired()
                    .HasColumnName("depart_place");

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasColumnName("doc_number");

                entity.Property(e => e.DocType)
                    .IsRequired()
                    .HasColumnName("doc_type");

                entity.Property(e => e.FlightNum)
                    .IsRequired()
                    .HasColumnName("flight_num");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.OperationPlace)
                    .IsRequired()
                    .HasColumnName("operation_place");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("operation_time");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasColumnName("	 operation_type");

                entity.Property(e => e.PassengerType)
                    .IsRequired()
                    .HasColumnName("passenger_type");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnName("patronymic");

                entity.Property(e => e.PnrId)
                    .IsRequired()
                    .HasColumnName("pnr_id");

                entity.Property(e => e.Refund).HasColumnName("refund");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname");

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasColumnName("ticket_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
