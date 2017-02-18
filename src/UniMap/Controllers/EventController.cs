using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniMap.Data;
using UniMap.Models;
using UniMap.DataAccess;

namespace UniMap.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventManager;

        public EventController(ApplicationDbContext context)
        {
            _eventManager = new EventRepository(context);
        }

        // GET: api/Event
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _eventManager.GetEvents();

            if (events == null || events.Count() < 1)
                return NoContent();

            return Ok(events);
        }

        // GET: api/Event/:id
        [HttpGet("{id}")]
        public IActionResult GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Event @event = _eventManager.GetEvent(id);

            if (@event == null)
                return NotFound();

            return Ok(@event);
        }

        // PUT: api/Event/:id
        [HttpPut("{id}")]
        public IActionResult PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != @event.ID)
                return BadRequest();

            try
            {
                _eventManager.EditEvent(id, @event);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Event
        [HttpPost]
        public IActionResult PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _eventManager.CreateEvent(@event);
            }
            catch (DbUpdateException)
            {
                if (EventExists(@event.ID))
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                else
                    throw;
            }

            return CreatedAtAction("GetEvent", new { id = @event.ID }, @event);
        }

        // DELETE: api/Event/:id
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_eventManager.DeleteEvent(id))
                return NotFound();

            return Ok();
        }

        private bool EventExists(int id)
        {
            return _eventManager.GetEvent(id) != null;
        }
    }
}