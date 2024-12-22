using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Api1.Models;
using Api1.Services;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivityService _activityService;

        public ActivitiesController(ActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetAllActivities()
        {
            return Ok(_activityService.GetAllActivities());
        }

        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivityById(int id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public ActionResult CreateActivity(Activity activity)
        {
            _activityService.CreateActivity(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateActivity(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            var existingActivity = _activityService.GetActivityById(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            _activityService.UpdateActivity(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteActivity(int id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            _activityService.DeleteActivity(id);
            return NoContent();
        }

        [HttpDelete("{id}/sessions/{sessionId}")]
        public ActionResult DeleteSession(int id, int sessionId)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            _activityService.DeleteSession(id, sessionId);
            return NoContent();
        }
    }
}
