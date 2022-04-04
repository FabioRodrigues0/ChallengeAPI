namespace ChallengeAPI.Services.DiagonalSumService;

public interface IDiagonalSumService
{
	Task<List<DiagonalSum>> GetDiagonalSum();

	Task<int> AddDiagonalSum(List<List<int>> sum);
}