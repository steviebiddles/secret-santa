using System;
using System.Collections.Generic;
using SecretSanta.Models;

namespace SecretSanta.Repositories
{
    public interface IEventsRepository
    {
        IEnumerable<Event> FindAll();
        Event FindById(int id);
        Event Save(Event @event, bool isUpdate = false);
        bool Delete(Event @event);
    }
}
