using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChallengeAPI.Services.RatioSumService;

public class RatioSumService : IRatioSumService
{
	private readonly DataContext _context;
	private static RatioSum ListInputs;
	private List<string> outputRatio;
	private decimal zeros;
	private decimal Pos;
	private decimal Neg;

	public RatioSumService(DataContext context)
	{
		_context = context;
	}

	public async Task<List<RatioSum>> GetRatioSum()
	{
		var response = await _context.Ratios.OrderByDescending(p => p.DateTime).ToListAsync();
		return response;
	}

	public async Task<int> AddRatioSum(List<int> sum)
	{
		ListInputs = new RatioSum();
		foreach(var n in sum)
		{
			if(n == 0)
				zeros++;
			else if(n > 0)
				Pos++;
			else if(n < 0)
				Neg++;
		}
		outputRatio = new List<string>();

		outputRatio.Add(string.Format("{0:N6}", Pos / sum.Count()));
		outputRatio.Add(string.Format("{0:N6}", zeros / sum.Count()));
		outputRatio.Add(string.Format("{0:N6}", Neg / sum.Count()));

		ListInputs.Input = JsonSerializer.Serialize(sum);
		ListInputs.Output = JsonSerializer.Serialize(outputRatio);
		_context.Ratios.Add(ListInputs);
		var response = await _context.SaveChangesAsync();

		return response;
	}
}