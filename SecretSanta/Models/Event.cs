using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSanta.Models
{
	[Table("events")]
    public class Event
    {
		[Key]
		[Column("id")]
        public int Id { get; set; }

		[Required]
		[Column("name")]
        public string Name { get; set; }
    }
}