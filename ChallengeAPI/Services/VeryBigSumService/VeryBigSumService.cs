using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChallengeAPI.Services.VeryBigSumService;

public class VeryBigSumService : IVeryBigSumService
{
	private readonly DataContext _context;
	private static VeryBigSum ListInputs;
	private static decimal finalSum;

	public VeryBigSumService(DataContext context)
	{
		_context = context;
	}

	public async Task<List<VeryBigSum>> GetVeryBigSum()
	{
		var response = await _context.VeryBigs.OrderByDescending(p => p.DateTime).ToListAsync();
		return response;
	}

	public async Task<int> AddVeryBigSum(List<int> sum)
	{
		ListInputs = new VeryBigSum();
		foreach(var inputs in sum)
		{
			finalSum += inputs;
		}
		ListInputs.Input = JsonSerializer.Serialize(sum);
		ListInputs.Output = finalSum.ToString();
		_context.VeryBigs.Add(ListInputs);
		var response = await _context.SaveChangesAsync();
		return response;
	}
}