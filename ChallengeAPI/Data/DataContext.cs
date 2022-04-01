using ChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<VeryBigSum>()
			.HasKey(s => new { s.Id });
		modelBuilder.Entity<DiagonalSum>()
			.HasKey(d => new { d.Id });
		modelBuilder.Entity<RatioSum>()
			.HasKey(r => new { r.Id });
	}

	public DbSet<VeryBigSum> VeryBigs { get; set; }
	public DbSet<DiagonalSum> Diagonals { get; set; }
	public DbSet<RatioSum> Ratios { get; set; }
}