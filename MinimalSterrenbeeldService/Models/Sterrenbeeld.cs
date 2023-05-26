using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MinimalSterrenbeeldService.Models;

public class Sterrenbeeld
{
	[Key]
	public int Id { get; set; }	
	[Required]
	[Range(1, 12)]

	public int VanMaand { get; set; }

	[Required]
	[Range(1, 31)] 
	public int VanDag { get; set; }

	[Required]
	[Range(1, 12)]

	public int TotMaand { get; set; }
	
	[Required]
	[Range(1, 31)] 
	public int TotDag { get; set; }
	
	[Required]
	public string SterrenBeeld { get; set; }



}
