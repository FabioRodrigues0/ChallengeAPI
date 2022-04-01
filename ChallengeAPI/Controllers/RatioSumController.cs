using System.Text.Json;
using ChallengeAPI.Models;
using ChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RatioSumController : ControllerBase
{
	private static RatioSum ListInputs;
	private List<string> outputRatio;
	private decimal zeros;
	private decimal Pos;
	private decimal Neg;

	private readonly DataContext _context;

	public RatioSumController(DataContext context)
	{
		_context = context;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<int> sum)
	{
		ListInputs = new RatioSum();

		if(sum.Count() == 0)
			return BadRequest();
		foreach(var n in sum)
		{
			if(n == 0)
				zeros++;
			else if(n > 0)
				Pos++;
			else if(n < 0)
				Neg++;
		}
		ListInputs.Input = JsonSerializer.Serialize(sum);
		outputRatio = new List<string>();

		outputRatio.Add(string.Format("{0,8:0.000000}", Pos / sum.Count()));
		outputRatio.Add(string.Format("{0,8:0.000000}", zeros / sum.Count()));
		outputRatio.Add(string.Format("{0,8:0.000000}", Neg / sum.Count()));
		ListInputs.Output = JsonSerializer.Serialize(outputRatio);
		_context.Ratios.Add(ListInputs);
		await _context.SaveChangesAsync();
		return Ok(ListInputs);
	}

	[HttpGet]
	public async Task<ActionResult<RatioSum>> Get()
	{
		var response = await _context.Ratios.OrderByDescending(p => p.DateTime).ToListAsync();
		return Ok(response);
	}
}