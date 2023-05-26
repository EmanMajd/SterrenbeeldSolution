using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalSterrenbeeldService.Models;
using MinimalSterrenbeeldService.Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;

namespace MinimalSterrenbeeldService.Controllers;

public class SterrenbeeldController : ControllerBase
{
	List<string> maanden = new List<string>(){ "januari", "februari", "maart", "april", "mei", "juni",
		"juli","augustus","september","oktober","november","december"};
	List<Sterrenbeeld> sterrenbeelds = new List<Sterrenbeeld>() { 
		new Sterrenbeeld(){ VanMaand = 12, VanDag = 22 , TotDag = 19 , TotMaand = 1,SterrenBeeld = "Steenbok" },
		new Sterrenbeeld(){ VanMaand = 1, VanDag = 20 , TotDag = 18 , TotMaand = 2,SterrenBeeld = "Waterman" },
		new Sterrenbeeld(){ VanMaand = 2, VanDag = 19 , TotDag = 20 , TotMaand = 3,SterrenBeeld = "Vissen" },
		new Sterrenbeeld(){ VanMaand = 3, VanDag = 21 , TotDag = 19 , TotMaand = 4,SterrenBeeld = "Ram" },
		new Sterrenbeeld(){ VanMaand = 4, VanDag = 20 , TotDag = 20 , TotMaand = 5,SterrenBeeld = "Stier" },
		new Sterrenbeeld(){ VanMaand = 5, VanDag = 21 , TotDag = 20 , TotMaand = 6,SterrenBeeld = "Stier" },
		new Sterrenbeeld(){ VanMaand = 6, VanDag = 21 , TotDag = 22 , TotMaand = 7,SterrenBeeld = "Kreeft" }

	};


	[HttpGet]
	public List<Sterrenbeeld> FindAll() {
		return sterrenbeelds;
	}
}
