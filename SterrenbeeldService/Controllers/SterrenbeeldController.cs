using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SterrenbeeldService.Models;
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
	public async Task<ActionResult>  GetSterrenAsync(int dag, int maand) {

		if (!IsValidDatum(dag, maand))
		{
			return base.BadRequest("Ongeldige dag of maand.");
		}

		string sterrenbeeld =  GetSterrenbeeld(dag, maand);
		return  base.Ok( sterrenbeeld);


	} //=> base.Ok(sterrenbeelden);

	private bool IsValidDatum(int dag, int maand)
	{
		return dag >= 1 && dag <= 31 && maand >= 1 && maand <= 12;
	}

	private string GetSterrenbeeld(int dag, int maand)
	{
		foreach (var sterrenbeeld in sterrenbeelden)
		{
			if ((maand == sterrenbeeld.StartMaand && dag >= sterrenbeeld.StartDag)
				|| (maand == sterrenbeeld.EindMaand && dag <= sterrenbeeld.EindDag))
			{
				return sterrenbeeld.Naam;
			}
		}

		return string.Empty;
	}
}


