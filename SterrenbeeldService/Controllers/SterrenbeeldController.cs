using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SterrenbeeldService.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Runtime.Intrinsics.Arm;

namespace SterrenbeeldService.Controllers;

[Route("sterrenbeelden")]
[ApiController]
public class SterrenbeeldController : ControllerBase
{



	private static List<Sterrenbeeld> sterrenbeelden = new List<Sterrenbeeld>()
		{
			new Sterrenbeeld(){Naam ="steenbok", StartDag =22, StartMaand=12, EindDag = 19,EindMaand = 1 },
			new Sterrenbeeld(){Naam ="waterman", StartDag =20, StartMaand=1, EindDag = 18,EindMaand = 2 },
			new Sterrenbeeld(){Naam ="vissen", StartDag = 19, StartMaand=2, EindDag = 20,EindMaand = 3 },
			new Sterrenbeeld(){Naam ="ram", StartDag = 21, StartMaand=3, EindDag = 19,EindMaand = 4 },
			new Sterrenbeeld(){Naam ="stier", StartDag = 20, StartMaand=4, EindDag = 20,EindMaand = 5 },
			new Sterrenbeeld(){Naam ="tweeling", StartDag = 21, StartMaand=5, EindDag = 20,EindMaand = 6 },
			new Sterrenbeeld(){Naam ="kreeft", StartDag = 21, StartMaand=6, EindDag = 22,EindMaand = 7 },
			new Sterrenbeeld(){Naam ="leeuw", StartDag = 23, StartMaand=7,EindDag = 22,EindMaand = 8 },
			new Sterrenbeeld(){Naam ="maagd", StartDag = 23, StartMaand=8, EindDag = 22,EindMaand = 9 },
			new Sterrenbeeld(){Naam ="weegschaal",StartDag = 23, StartMaand=9, EindDag = 22,EindMaand = 10 },
			new Sterrenbeeld(){Naam ="schorpioen", StartDag = 23, StartMaand=10,EindDag =  21,EindMaand = 11 },
			new Sterrenbeeld(){Naam ="boogschutter", StartDag = 22, StartMaand = 11, EindDag = 21,EindMaand = 12 }
		};

	[HttpGet]
	public async Task<ActionResult> FindAll() =>
		base.Ok(sterrenbeelden);

	[HttpGet("{dag}-{maand}")]
	public ActionResult GetSterren(int dag, int maand) {

		
		string sterrenbeeld = GetSterrenbeeld(dag, maand);
		return base.Ok($" Je sterrenbeeld is {sterrenbeeld}");


	}


	[NonAction]
	public string GetSterrenbeeld(int dag, int maand)
	{
		int jaar = 2020;
		try
		{
			DateTime dateTime = new DateTime(jaar, maand, dag);
			string sterrenbeeldNaam = null;

			foreach (var sterrenbeeld in sterrenbeelden)
			{
				DateTime startdate = new DateTime(jaar, sterrenbeeld.StartMaand, sterrenbeeld.StartDag);
				DateTime eindtdate = new DateTime(jaar, sterrenbeeld.EindMaand, sterrenbeeld.EindDag);

				if (dateTime >= startdate && dateTime <= eindtdate ) 
					sterrenbeeldNaam =  sterrenbeeld.Naam;

				if (startdate.Month == 12 && startdate.Day >= 22 || eindtdate.Month == 1 && eindtdate.Day <= 19)
					sterrenbeeldNaam = "steenbok";
			}


			return sterrenbeeldNaam;

		}
		catch (Exception ex)
		{
			return $"Invalid date: {ex.Message}";
		}

	}

}


//bool v1 = DateTime.Equals(dateTime, startdate);
//bool v2 = DateTime.Equals(dateTime, eindtdate);
//if (v1 || v2) return sterrenbeeld.Naam;

//int valid1 = DateTime.Compare(dateTime, startdate);
//int valid2 = DateTime.Compare(dateTime, eindtdate);
//if (valid1 <= 0 || valid2 >= 0) return sterrenbeeld.Naam;
