using ChallengeAPI.Data;
using ChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DiagonalSumController : ControllerBase
{
	private static DiagonalSum ListInputs;
	private static int leftDiagonal;
	private static int rightDiagonal;
	private int j = 0;
	private int k = 0;
	private int i = 0;
	private readonly DataContext _context;

	public DiagonalSumController(DataContext context)
	{
		_context = context;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<List<int>> sum)
	{
		ListInputs = new DiagonalSum();

		if(sum.Count() == 0)
			return BadRequest();
		for(i = 0, j = 0, k = (sum.Count() - 1);i < sum.Count();i++, j++, k--)
		{
			leftDiagonal += sum[i][j];
			rightDiagonal += sum[i][k];
		}
		ListInputs.Input = JsonSerializer.Serialize(sum);
		ListInputs.Output = Math.Abs(leftDiagonal - rightDiagonal).ToString();
		_context.Diagonals.Add(ListInputs);
		await _context.SaveChangesAsync();
		return Ok(ListInputs);
	}

	[HttpGet]
	public async Task<ActionResult<DiagonalSum>> Get()
	{
		var response = await _context.Diagonals.OrderByDescending(p => p.DateTime).ToListAsync();
		return Ok(response);
	}
}