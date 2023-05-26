using System.ComponentModel.DataAnnotations;

namespace SterrenbeeldService.Models;

public class Sterrenbeeld
{
	
	
	[Required]
	public string Naam { get; set; }
	public int StartDag { get; set; }
	[Required]
	[Range(1, 12)]
	public int StartMaand { get; set; }
	public int EindDag { get; set; }
	[Required]
	[Range(1, 12)]
	public int EindMaand { get; set; }

}
