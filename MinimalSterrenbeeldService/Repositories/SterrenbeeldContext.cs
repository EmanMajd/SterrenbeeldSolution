using Microsoft.EntityFrameworkCore;
using MinimalSterrenbeeldService.Models;

namespace MinimalSterrenbeeldService.Repositories;

public class SterrenbeeldContext : DbContext
{
	List<Sterrenbeeld> sterrenbeelds = new List<Sterrenbeeld>() {
		new Sterrenbeeld(){ VanMaand = 12, VanDag = 22 , TotDag = 19 , TotMaand = 1,SterrenBeeld = "Steenbok" },
		new Sterrenbeeld(){ VanMaand = 1, VanDag = 20 , TotDag = 18 , TotMaand = 2,SterrenBeeld = "Waterman" },
		new Sterrenbeeld(){ VanMaand = 2, VanDag = 19 , TotDag = 20 , TotMaand = 3,SterrenBeeld = "Vissen" },
		new Sterrenbeeld(){ VanMaand = 3, VanDag = 21 , TotDag = 19 , TotMaand = 4,SterrenBeeld = "Ram" },
		new Sterrenbeeld(){ VanMaand = 4, VanDag = 20 , TotDag = 20 , TotMaand = 5,SterrenBeeld = "Stier" },
		new Sterrenbeeld(){ VanMaand = 5, VanDag = 21 , TotDag = 20 , TotMaand = 6,SterrenBeeld = "Stier" },
		new Sterrenbeeld(){ VanMaand = 6, VanDag = 21 , TotDag = 22 , TotMaand = 7,SterrenBeeld = "Kreeft" }

	};


	public SterrenbeeldContext(DbContextOptions<SterrenbeeldContext> options) : base(options) { }


	public DbSet<Sterrenbeeld> sterrenbeelden => Set<Sterrenbeeld>();
	/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName)
				.AddJsonFile("appsettings.json", false).Build();
			var connectionString =
				configuration.GetConnectionString("Sterrenbeeld");
			if (connectionString != null)
				optionsBuilder.UseSqlServer(connectionString,
					options => options.MaxBatchSize(150));
		}
		else
			testMode = true;

	}*/

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//if (!testMode)
		//{
		//modelBuilder.Entity<Sterrenbeeld>().HasNoKey();
		modelBuilder.Entity<Sterrenbeeld>().HasData(
		new Sterrenbeeld() { Id = 1, VanMaand = 12, VanDag = 22, TotDag = 19, TotMaand = 1, SterrenBeeld = "Steenbok" },
		new Sterrenbeeld() { Id = 2, VanMaand = 1, VanDag = 20, TotDag = 18, TotMaand = 2, SterrenBeeld = "Waterman" },
		new Sterrenbeeld() { Id = 3, VanMaand = 2, VanDag = 19, TotDag = 20, TotMaand = 3, SterrenBeeld = "Vissen" },
		new Sterrenbeeld() { Id = 4, VanMaand = 3, VanDag = 21, TotDag = 19, TotMaand = 4, SterrenBeeld = "Ram" },
		new Sterrenbeeld() { Id = 5, VanMaand = 4, VanDag = 20, TotDag = 20, TotMaand = 5, SterrenBeeld = "Stier" },
		new Sterrenbeeld() { Id = 6, VanMaand = 5, VanDag = 21, TotDag = 20, TotMaand = 6, SterrenBeeld = "Stier" },
		new Sterrenbeeld() { Id = 7, VanMaand = 6, VanDag = 21, TotDag = 22, TotMaand = 7, SterrenBeeld = "Kreeft" }
		);

		//}

	}

}
