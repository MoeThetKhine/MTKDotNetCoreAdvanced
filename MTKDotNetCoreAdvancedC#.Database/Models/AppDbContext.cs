namespace MTKDotNetCoreAdvancedC_.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=AdvancedC#;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_blog");

            entity.Property(e => e.BlogAuthor).HasMaxLength(50);
            entity.Property(e => e.BlogContent).HasMaxLength(50);
            entity.Property(e => e.BlogTitle).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    #endregion

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
