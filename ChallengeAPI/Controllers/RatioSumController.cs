using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RatioSumController : ControllerBase
{
	private readonly IRatioSumService _ratioSumService;

	public RatioSumController(IRatioSumService ratioSumService)
	{
		_ratioSumService = ratioSumService;
	}

	[HttpPost]
	public async Task<ActionResult<List<int>>> Post([FromBody] List<int> sum)
	{
		if(sum.Count() == 0)
			return BadRequest("Tem que inserir pelo menos um numero");
		await _ratioSumService.AddRatioSum(sum);
		return Ok("Dados inseridos com sucesso");
	}

	[HttpGet]
	public async Task<ActionResult<RatioSum>> Get()
	{
		var result = await _ratioSumService.GetRatioSum();
		return Ok(result);
	}
}