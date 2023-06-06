
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SterrenbeeldService.Controllers;
using System.Net;




Console.Write("Geef de dag van je geboortedatum: ");
int dag = int.Parse(Console.ReadLine()!);

Console.Write("Geef de maand van je geboortedatum: ");
int maand = int.Parse(Console.ReadLine()!);


using var client = new HttpClient(); 
var response = await client.GetAsync($"http://localhost:5000/sterrenbeelden/{dag}-{maand}");
switch (response.StatusCode) 
{
case HttpStatusCode.OK:
		string sterrenbeeld1 = response.Content.ReadAsStringAsync().Result;
		Console.WriteLine(sterrenbeeld1);
		break;
case HttpStatusCode.NotFound: 
Console.WriteLine("foutieve");
	break;
	default:
Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
	break;
}

/*app.MapGet("sterrenbeelden", (SterrenbeeldController db) =>
 db.FindAll().ToString());*/



