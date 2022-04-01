using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeAPI.Models;

public class VeryBigSum
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Key]
	public Guid Id { get; set; }

	public string Input { get; set; } = string.Empty;
	public string Output { get; set; } = string.Empty;
	public DateTime DateTime { get; set; } = DateTime.Now;
}