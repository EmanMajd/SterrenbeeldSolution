
using SterrenbeeldService.Controllers;
using System.Net;


Console.Write("Geef de dag van je geboortedatum: ");
int dag = int.Parse(Console.ReadLine()!);

Console.Write("Geef de maand van je geboortedatum: ");
int maand = int.Parse(Console.ReadLine()!);

// zonder client request
SterrenbeeldController controller = new SterrenbeeldController();
string sterren = controller.GetSterrenbeeld(dag, maand);

Console.WriteLine($"Je sterren is: {sterren}");

// met client request
string sterrenbeeld = GetSterrenbeeld(dag, maand);

Console.WriteLine($"Je sterrenbeeld is: {sterrenbeeld}");




static string GetSterrenbeeld(int dag, int maand)
{
	using (var client = new HttpClient())
	{
		string apiUrl = $"http://localhost:5000/sterrenbeelden/{dag}-{maand}";
		var response = client.GetAsync($"http://localhost:5000/sterrenbeelden/{dag}-{maand}").Result; 
		//var response = await client.GetAsync(apiUrl).Result;

		if (response.StatusCode == HttpStatusCode.OK)
		{
			Console.WriteLine(response.Content.ReadAsAsync<string>());
			return response.Content.ReadAsAsync<string>().Result.ToString();
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



