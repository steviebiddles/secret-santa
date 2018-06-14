using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Data;
using SecretSanta.Models;
using SecretSanta.Requests;

namespace SecretSanta.Controllers.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/events")]
    public class EventsController : Controller
    {
        private readonly SecretSantaContext db;

        public EventsController(SecretSantaContext context)
        {
            this.db = context;
        }

        [HttpGet(Name = "ApiV1GetEvents")]
        public IEnumerable<Event> GetAll()
        {
            return this.db.Events.ToList();
        }

        [HttpGet("{id}", Name = "ApiV1GetEvent")]
        public IActionResult GetOne(int id)
        {
            var item = this.db.Events.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Creates an event
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /events
        ///     {
        ///        "name": "Name of sample event"
        ///     }
        ///
        /// </remarks>
        [HttpPost(Name = "ApiV1PostEvent")]
        public IActionResult Post([FromBody] EventRequest eventRequest)
        {
            if (eventRequest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(eventRequest);
            }

            var item = new Event
            {
                Name = eventRequest.Name
            };

            this.db.Events.Add(item);
            this.db.SaveChanges();

            return CreatedAtRoute("ApiV1GetEvent", new { id = item.Id }, item);
        }

        [HttpPatch("{id}", Name = "ApiV1PatchEvent")]
        public void Patch(int id, [FromBody]string value)
        {
        }

        [HttpPut("{id}", Name = "ApiV1PutEvent")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}", Name = "ApiV1DeleteEvent")]
        public IActionResult Delete(int id)
        {
            var item = this.db.Events.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            this.db.Events.Remove(item);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
