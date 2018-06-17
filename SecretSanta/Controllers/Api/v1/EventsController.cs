using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Data;
using SecretSanta.Models;
using SecretSanta.Requests;
using SecretSanta.Repositories;

namespace SecretSanta.Controllers.Api.v1
{
    [Produces("application/json")]
    [Route("api/v1/events")]
    public class EventsController : Controller
    {
        private readonly IEventsRepository eventsRepository;

        public EventsController(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        [HttpGet(Name = "ApiV1GetEvents")]
        public IEnumerable<Event> GetAll()
        {
            return this.eventsRepository.FindAll();
        }

        [HttpGet("{id}", Name = "ApiV1GetEvent")]
        public IActionResult GetOne(int id)
        {
            var @event = this.eventsRepository.FindById(id);

            if (@event != null)
            {
                return this.Ok(@event);
            }

            return this.NotFound();
        }

        /// <summary>
        /// Creates an event
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /events
        ///     {
        ///        "name": "Name of sample event"
        ///     }
        /// </remarks>
        /// <param name="eventRequest">Event request.</param>
        /// <returns>Location if successful.</returns> 
        [HttpPost(Name = "ApiV1PostEvent")]
        public IActionResult Post([FromBody] EventRequest eventRequest)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(eventRequest);
            }

            var @event = new Event
            {
                Name = eventRequest.Name
            };

            @event = this.eventsRepository.Save(@event);

            if (@event != null)
            {
                return this.CreatedAtRoute("ApiV1GetEvent", new { id = @event.Id }, null);
            }

            return this.BadRequest();
        }

        [HttpPatch("{id}", Name = "ApiV1PutEvent")]
        public IActionResult Patch(int id, [FromBody] EventRequest eventRequest)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(eventRequest);
            }

            var @event = this.eventsRepository.FindById(id);
            @event.Name = eventRequest.Name;

            if (this.eventsRepository.Save(@event, true) != null)
            {
                return this.NoContent();
            }

            return this.BadRequest();
        }

        [HttpPut("{id}", Name = "ApiV1PatchEvent")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}", Name = "ApiV1DeleteEvent")]
        public IActionResult Delete(int id)
        {
            var @event = this.eventsRepository.FindById(id);

            if (@event == null)
            {
                return this.NotFound();
            }

            if (this.eventsRepository.Delete(@event))
            {
                return this.NoContent();
            }

            return this.BadRequest();
        }
    }
}
