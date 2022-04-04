namespace ChallengeAPI.Services.RatioSumService;

public interface IRatioSumService
{
	Task<List<RatioSum>> GetRatioSum();

	Task<int> AddRatioSum(List<int> sum);
}