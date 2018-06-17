using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;
using SecretSanta.Models;

namespace SecretSanta.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly SecretSantaContext context;

        public EventsRepository(SecretSantaContext context)
        {
            this.context = context;
        }

        public IEnumerable<Event> FindAll()
        {
            return this.context.Events.ToList();
        }

        public Event FindById(int id)
        {
            return this.context.Events.Find(id);
        }

        public bool Delete(Event @event)
        {
            try
            {
                this.context.Events.Remove(@event);
                this.context.SaveChanges();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public Event Save(Event @event, bool isUpdate = false)
        {
            if (isUpdate) {
                this.context.Events.Update(@event);
            } else {
                this.context.Events.Add(@event);
            }

            this.context.SaveChanges();

            return @event;
        }
    }
}
