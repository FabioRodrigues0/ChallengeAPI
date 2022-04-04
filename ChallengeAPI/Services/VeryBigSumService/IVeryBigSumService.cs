namespace ChallengeAPI.Services.VeryBigSumService;

public interface IVeryBigSumService
{
	Task<List<VeryBigSum>> GetVeryBigSum();

	Task<int> AddVeryBigSum(List<int> sum);
}