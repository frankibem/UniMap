using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniMap.Models;

namespace UniMap.Data_Access
{
    public interface IEventRepository
    {
        int CreateEvent(Event @event);

        bool EditEvent(Event @event);

        bool DeleteEvent(int eventID);

        Event GetEvent(int eventID);

        IEnumerable<Event> GetEvents(IEnumerable<int> eventIDs);

        IEnumerable<Event> GetEventsByTags(IEnumerable<Tag> tags);

        int CreateTag(Tag tag);

        Tag GetTag(int tagID);
    }
}
