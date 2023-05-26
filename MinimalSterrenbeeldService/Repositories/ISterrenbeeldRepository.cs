using MinimalSterrenbeeldService.Models;

namespace MinimalSterrenbeeldService.Repositories;

public interface ISterrenbeeldRepository
{
	List<Sterrenbeeld> getAllSterrenbeelds();
}
