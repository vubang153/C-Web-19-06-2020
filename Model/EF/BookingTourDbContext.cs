namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingTourDbContext : DbContext
    {
        public BookingTourDbContext()
            : base("name=BookingTourDbContext")
        {
        }

        public virtual DbSet<Account_blance> Account_blance { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Tour_Detail> Tour_Detail { get; set; }
        public virtual DbSet<TourCategory> TourCategories { get; set; }
        public virtual DbSet<TourComment> TourComments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.main_image)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Tour)
                .HasForeignKey(e => e.tour_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
