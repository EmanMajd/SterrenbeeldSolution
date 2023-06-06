using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SterrenbeeldService.Models;
using System;
using System.Runtime.Intrinsics.Arm;

namespace SterrenbeeldService.Controllers;

[Route("sterrenbeelden")]
[ApiController]
public class SterrenbeeldController : ControllerBase
{



	private static List<Sterrenbeeld> sterrenbeelden = new List<Sterrenbeeld>()
		{
			new Sterrenbeeld(){Naam = "steenbok",StartDag = 22, StartMaand= 12, EindDag = 19, EindMaand = 1 },
			new Sterrenbeeld(){Naam ="waterman", StartDag =20, StartMaand=1, EindDag = 19,EindMaand = 2 },
			new Sterrenbeeld(){Naam ="vissen", StartDag = 20, StartMaand=2, EindDag = 20,EindMaand = 3 },
			new Sterrenbeeld(){Naam ="ram", StartDag = 21, StartMaand=3, EindDag = 20,EindMaand = 4 },
			new Sterrenbeeld(){Naam ="stier", StartDag = 21, StartMaand=4, EindDag = 20,EindMaand = 5 },
			new Sterrenbeeld(){Naam ="tweeling", StartDag = 21, StartMaand=5, EindDag = 21,EindMaand = 6 },
			new Sterrenbeeld(){Naam ="kreeft", StartDag = 21, StartMaand=6, EindDag = 20,EindMaand = 7 },
			new Sterrenbeeld(){Naam ="leeuw", StartDag = 23, StartMaand=7,EindDag = 23,EindMaand = 8 },
			new Sterrenbeeld(){Naam ="maagd", StartDag = 24, StartMaand=8, EindDag = 23,EindMaand = 9 },
			new Sterrenbeeld(){Naam ="weegschaal",StartDag = 24, StartMaand=9, EindDag = 23,EindMaand = 10 },
			new Sterrenbeeld(){Naam ="schorpioen", StartDag = 24, StartMaand=10,EindDag =  22,EindMaand = 11 },
			new Sterrenbeeld(){Naam ="boogschutter", StartDag = 23, StartMaand = 11, EindDag = 21,EindMaand = 12 }
		};


	[HttpGet("{dag}-{maand}")]
	public ActionResult GetSterren(int dag, int maand) {

		if (!IsValidDatum(dag, maand))
		{
			return base.BadRequest("Ongeldige dag of maand.");
		}

		string sterrenbeeld = GetSterrenbeeld(dag, maand);
		return base.Ok(sterrenbeeld);


	} //=> base.Ok(sterrenbeelden);

	private bool IsValidDatum(int dag, int maand)
	{
		return dag >= 1 && dag <= 31 && maand >= 1 && maand <= 12;
	}

	public string GetSterrenbeeld(int dag, int maand)
	{
		int jaar = 2020;
		try
		{
			string date = $"{jaar}{maand}{dag}";
			DateTime dateTime = new DateTime(jaar, maand, dag);
		
			foreach (var sterrenbeeld in sterrenbeelden)
			{
				DateTime startdate = new DateTime(jaar, sterrenbeeld.StartMaand, sterrenbeeld.StartDag);
				DateTime eindtdate = new DateTime(jaar, sterrenbeeld.EindMaand, sterrenbeeld.EindDag);

				bool v1 = DateTime.Equals(dateTime, startdate);
				bool v2 = DateTime.Equals(dateTime, eindtdate);

				if (v1 || v2) return sterrenbeeld.Naam;
				
				/*DateTime validDate;
				bool t= DateTime.TryParse( date, out validDate);

				bool x1 = DateTime.Equals(validDate, startdate);
				bool x2 = DateTime.Equals(validDate, eindtdate);

				if (t)
				{

					if (x1 || x2) return sterrenbeeld.Naam;
				}*/

				
			}

		}
		catch (Exception ex)
		{
			return $"Invalid date: {ex.Message}";
		}
		return string.Empty;

	}


	/*private string GetSterrenbeeld(int dag, int maand)
	{

		if (maand > 12 || maand < 1) return "Tick een maandnummer tussen 1 en 12";
		else if (dag < 1 || dag > 31)
		{
			if (maand == 2)
			{
				if (dag > 29) return "Maand february heeft alleen 29 dagen";
			}
		}
		else
		{
			foreach (var sterrenbeeld in sterrenbeelden)
			{

				if ((maand == sterrenbeeld.StartMaand && dag >= sterrenbeeld.StartDag)
					|| (maand == sterrenbeeld.EindMaand && dag <= sterrenbeeld.EindDag))
				{
					return sterrenbeeld.Naam;
				}
			}

		}
		return string.Empty;

	}*/
}


