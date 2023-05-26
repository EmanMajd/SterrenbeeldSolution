using MinimalSterrenbeeldService.Repositories;
using MinimalSterrenbeeldService.Models;
using Microsoft.EntityFrameworkCore;
using MinimalSterrenbeeldService.Controllers;

List<Sterrenbeeld> sterrenbeelds = new List<Sterrenbeeld>() {
		new Sterrenbeeld() { Id = 1, VanMaand = 12, VanDag = 22, TotDag = 19, TotMaand = 1, SterrenBeeld = "Steenbok" },
		new Sterrenbeeld() { Id = 2, VanMaand = 1, VanDag = 20, TotDag = 18, TotMaand = 2, SterrenBeeld = "Waterman" },
		new Sterrenbeeld() { Id = 3, VanMaand = 2, VanDag = 19, TotDag = 20, TotMaand = 3, SterrenBeeld = "Vissen" },
		new Sterrenbeeld() { Id = 4, VanMaand = 3, VanDag = 21, TotDag = 19, TotMaand = 4, SterrenBeeld = "Ram" },
		new Sterrenbeeld() { Id = 5, VanMaand = 4, VanDag = 20, TotDag = 20, TotMaand = 5, SterrenBeeld = "Stier" },
		new Sterrenbeeld() { Id = 6, VanMaand = 5, VanDag = 21, TotDag = 20, TotMaand = 6, SterrenBeeld = "Stier" },
		new Sterrenbeeld() { Id = 7, VanMaand = 6, VanDag = 21, TotDag = 22, TotMaand = 7, SterrenBeeld = "Kreeft" }

	};
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SterrenbeeldContext>(opt => opt.UseInMemoryDatabase("sterrenbeelden"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

/*app.MapGet("/sterrenbeelden",  (SterrenbeeldContext db) =>
 db.sterrenbeelden.ToList());*/

/*app.MapGet("sterrenbeelden", (SterrenbeeldController db) =>
 db.FindAll().ToString());*/



app.Run();