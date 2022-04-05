using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VeryBigSumController : ControllerBase
{
	private readonly IVeryBigSumService _veryBigSumService;

	public VeryBigSumController(IVeryBigSumService veryBigSumService)
	{
		_veryBigSumService = veryBigSumService;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<int> sum)
	{
		if(!sum.Any())
			return BadRequest("Tem que inserir pelo menos um numero");
		await _veryBigSumService.AddVeryBigSum(sum);
		return Ok("Dados inseridos com sucesso");
	}

	[HttpGet]
	public async Task<ActionResult<VeryBigSum>> Get()
	{
		var result = await _veryBigSumService.GetVeryBigSum();
		if(result.Count() == 0)
			return Ok("Não contem dados");
		return Ok(result);
	}
}