using MinimalSterrenbeeldService.Models;

namespace MinimalSterrenbeeldService.Repositories;

public class SterrenbeeldRepository : ISterrenbeeldRepository
{
	readonly SterrenbeeldContext context;

	public SterrenbeeldRepository(SterrenbeeldContext context) { this.context = context; }
	
	public List<Sterrenbeeld> getAllSterrenbeelds()

	{
		return context.sterrenbeelden.ToList();
	}
}
