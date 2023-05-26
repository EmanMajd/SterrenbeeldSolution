using Microsoft.AspNetCore.Builder;
using SterrenbeeldService.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;





Console.Write("Geef de dag van je geboortedatum: ");
int dag = int.Parse(Console.ReadLine()!);

Console.Write("Geef de maand van je geboortedatum: ");
int maand = int.Parse(Console.ReadLine()!);

string sterrenbeeld = GetSterrenbeeld(dag, maand);

Console.WriteLine($"Je sterrenbeeld is: {sterrenbeeld}");



static string GetSterrenbeeld(int dag, int maand)
{
	using (var client = new HttpClient())
	{
		string apiUrl = $"http://localhost:5000/api/sterrenbeelden/{dag}-{maand}";
		var response = client.GetAsync(apiUrl).Result;

		if (response.StatusCode == HttpStatusCode.OK)
		{
			Console.WriteLine(response.Content.ReadAsStringAsync().Result);

			return response.Content.ReadAsStringAsync().Result;
		}
		else if (response.StatusCode == HttpStatusCode.BadRequest)
		{
			Console.WriteLine("Ongeldige invoer");
			throw new Exception("Ongeldige invoer");

		}
		else
		{
			Console.WriteLine("Er is een fout opgetreden bij het ophalen van het sterrenbeeld.");

			throw new Exception("Er is een fout opgetreden bij het ophalen van het sterrenbeeld.");
		}
	}
}
	

/*app.MapGet("sterrenbeelden", (SterrenbeeldController db) =>
 db.FindAll().ToString());*/



