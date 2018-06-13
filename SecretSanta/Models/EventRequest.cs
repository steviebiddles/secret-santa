using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Models
{
    public class EventRequest
    {
        [Required, MinLength(3)]
        public string Name { get; set; }
    }
}