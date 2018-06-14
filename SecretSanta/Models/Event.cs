using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SecretSanta.Models
{
    [DataContract]
	[Table("events")]
    public class Event
    {
		[Key]
        [DataMember]
		[Column("id")]
        public int Id { get; set; }

        [DataMember]
        [Required, MinLength(3)]
		[Column("name", TypeName = "varchar(128)")]
        public string Name { get; set; }
    }
}