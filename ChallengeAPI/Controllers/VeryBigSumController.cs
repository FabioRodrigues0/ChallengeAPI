using System.Text.Json;
using System.Text.Json.Serialization;
using ChallengeAPI.Data;
using ChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VeryBigSumController : ControllerBase
{
	private static VeryBigSum ListInputs;
	private static decimal finalSum;
	private readonly DataContext _context;

	public VeryBigSumController(DataContext context)
	{
		_context = context;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<int> sum)
	{
		ListInputs = new VeryBigSum();

		if(!sum.Any())
			return BadRequest();
		foreach(var inputs in sum)
		{
			finalSum += inputs;
		}
		ListInputs.Input = JsonSerializer.Serialize(sum);
		ListInputs.Output = finalSum.ToString();
		_context.VeryBigs.Add(ListInputs);
		await _context.SaveChangesAsync();
		return Ok(ListInputs);
	}

	[HttpGet]
	public async Task<ActionResult<VeryBigSum>> Get()
	{
		var response = await _context.VeryBigs.OrderByDescending(p => p.DateTime).ToListAsync();
		return Ok(response);
	}
}