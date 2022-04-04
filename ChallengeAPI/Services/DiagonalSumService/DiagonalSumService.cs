using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChallengeAPI.Services.DiagonalSumService;

public class DiagonalSumService : IDiagonalSumService
{
	private readonly DataContext _context;
	private static DiagonalSum ListInputs;
	private static int leftDiagonal;
	private static int rightDiagonal;
	private int j = 0;
	private int k = 0;
	private int i = 0;

	public DiagonalSumService(DataContext context)
	{
		_context = context;
	}

	public async Task<List<DiagonalSum>> GetDiagonalSum()
	{
		var response = await _context.Diagonals.OrderByDescending(p => p.DateTime).ToListAsync();
		return response;
	}

	public async Task<int> AddDiagonalSum(List<List<int>> sum)
	{
		ListInputs = new DiagonalSum();
		for(i = 0, j = 0, k = (sum.Count() - 1);i < sum.Count();i++, j++, k--)
		{
			leftDiagonal += sum[i][j];
			rightDiagonal += sum[i][k];
		}
		ListInputs.Input = JsonSerializer.Serialize(sum);
		ListInputs.Output = Math.Abs(leftDiagonal - rightDiagonal).ToString();
		_context.Diagonals.Add(ListInputs);
		var response = await _context.SaveChangesAsync();
		return response;
	}
}