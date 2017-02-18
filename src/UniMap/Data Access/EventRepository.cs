using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UniMap.Data;
using UniMap.Models;

namespace UniMap.DataAccess
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Given an event ID, return an event (or null if no events were found).
        /// </summary>
        public Event GetEvent(int eventID)
        {
            var @event = _db.Events.FirstOrDefault(e => e.ID == eventID);
            @event.Tags = GetTagsByEventID(eventID).ToList();

            return @event;
        }

        /// <summary>
        /// Given several event IDs, return the corresponding events (or empty).
        /// </summary>
        public IEnumerable<Event> GetEvents()
        {
            var events = _db.Events;
            foreach (var @event in events)
            {
                @event.Tags = GetTagsByEventID(@event.ID).ToList();
            }

            return events.OrderBy(e => e.StartOn).OrderBy(e => e.EndOn);
        }

        /// <summary>
        /// Get all the events with the associated tag (or empty).
        /// </summary>
        public IEnumerable<Event> GetEventsByTags(IEnumerable<Tag> tags)
        {
            var tagsHash = new HashSet<int>(tags.Select(t => t.ID));

            return (from e in _db.Events
                    where e.Tags.Any(t => tagsHash.Contains(t.ID))
                    select e).Include(e => e.Tags)
                    .OrderBy(e => e.StartOn).OrderBy(e => e.EndOn);
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
        public bool EditEvent(int id, Event @event)
        {
            var dbEvent = GetEvent(id);

            if (dbEvent == null) return false;

            dbEvent.Address = @event.Address;
            dbEvent.Description = @event.Description;
            dbEvent.EndOn = @event.EndOn;
            dbEvent.Latitude = @event.Latitude;
            dbEvent.Longitude = @event.Longitude;
            dbEvent.StartOn = @event.StartOn;
            dbEvent.Tags = @event.Tags;
            dbEvent.Title = @event.Title;

            _db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Given an ID, return a tag or null.
        /// </summary>
        public Tag GetTag(int tagID)
        {
            return _db.Tags.FirstOrDefault(t => t.ID == tagID);
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
            catch (Exception)
            {
                return -1;
            }

            return savedTag.ID;
        }

        /// <summary>
        /// Get all the tags for a given event ID
        /// </summary>
        private IEnumerable<Tag> GetTagsByEventID(int eventID)
        {
            return _db.EventTags.Where(et => et.EventID == eventID)
                                .Select(et => et.Tag);
        }
    }
}
