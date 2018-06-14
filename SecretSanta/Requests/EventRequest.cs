using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Requests
{
    public class EventRequest
    {
        [Required, MinLength(3)]
        public string Name { get; set; }
    }
}