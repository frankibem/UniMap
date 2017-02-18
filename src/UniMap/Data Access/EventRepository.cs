using System;
using System.Collections.Generic;
using System.Linq;
using UniMap.Data;
using UniMap.Models;

namespace UniMap.Data_Access
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Save the given event in the store. Return -1 if unable to save.
        /// </summary>
        public int CreateEvent(Event @event)
        {
            Event savedEvent = null;

            try
            {
                savedEvent = _db.Events.Add(@event).Entity;
                _db.SaveChanges();
            }
            catch(Exception)
            {
                return -1;
            }

            return savedEvent.ID;
        }

        /// <summary>
        /// Save the given tag in the store. Return -1 if unable to save.
        /// </summary>
        public int CreateTag(Tag tag)
        {
            Tag savedTag = null;

            try
            {
                savedTag = _db.Tags.Add(tag).Entity;
                _db.SaveChanges();
            }
            catch(Exception)
            {
                return -1;
            }

            return savedTag.ID;
        }

        /// <summary>
        /// Find the event with the corresponding ID and delete. True represents that the delete was successful.
        /// </summary>
        public bool DeleteEvent(int eventID)
        {
            var dbEvent = GetEvent(eventID);

            if (dbEvent == null) return false;

            _db.Events.Remove(dbEvent);
            return true;
        }

        /// <summary>
        /// Find the given event in the store and update the data.
        /// </summary>
        public bool EditEvent(Event @event)
        {
            var dbEvent = GetEvent(@event.ID);

            if (dbEvent == null) return false;

            dbEvent.Address = @event.Address;
            dbEvent.City = @event.City;
            dbEvent.Country = @event.Country;
            dbEvent.EndOn = @event.EndOn;
            dbEvent.Latitude = @event.Latitude;
            dbEvent.Longitude = @event.Longitude;
            dbEvent.PostalCode = @event.PostalCode;
            dbEvent.StartOn = @event.StartOn;
            dbEvent.State = @event.State;
            dbEvent.Tags = @event.Tags;
            dbEvent.Title = @event.Title;

            _db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Given an event ID, return an event (or null if no events were found).
        /// </summary>
        public Event GetEvent(int eventID)
        {
            return _db.Events.FirstOrDefault(e => e.ID == eventID);
        }

        /// <summary>
        /// Given several event IDs, return the corresponding events (or empty).
        /// </summary>
        public IEnumerable<Event> GetEvents(IEnumerable<int> eventIDs)
        {
            var eventIDsHash = new HashSet<int>(eventIDs);

            return _db.Events.Where(e => eventIDsHash.Contains(e.ID));
        }

        /// <summary>
        /// Get all the events with the associated tag (or empty).
        /// </summary>
        public IEnumerable<Event> GetEventsByTags(IEnumerable<Tag> tags)
        {
            var tagsHash = new HashSet<int>(tags.Select(t => t.ID));

            return from e in _db.Events
                   where e.Tags.Any(t => tagsHash.Contains(t.ID))
                   select e;
        }

        /// <summary>
        /// Given an ID, return a tag or null.
        /// </summary>
        public Tag GetTag(int tagID)
        {
            return _db.Tags.FirstOrDefault(t => t.ID == tagID);
        }
    }
}
