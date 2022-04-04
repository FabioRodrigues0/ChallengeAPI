using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DiagonalSumController : ControllerBase
{
	private readonly IDiagonalSumService _diagonalSumService;

	public DiagonalSumController(IDiagonalSumService diagonalSumService)
	{
		_diagonalSumService = diagonalSumService;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<List<int>> sum)
	{
		if(sum.Count() == 0)
			return BadRequest("Tem que inserir pelo menos um numero");
		await _diagonalSumService.AddDiagonalSum(sum);
		return Ok("Dados inseridos com sucesso");
	}

	[HttpGet]
	public async Task<ActionResult<DiagonalSum>> Get()
	{
		var result = await _diagonalSumService.GetDiagonalSum();
		return Ok(result);
	}
}