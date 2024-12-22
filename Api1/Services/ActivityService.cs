using System.Collections.Generic;
using System.Linq;
using Api1.Models;

namespace Api1.Services
{
    public class ActivityService
    {
        private static List<Activity> Activities = new List<Activity>();

        public IEnumerable<Activity> GetAllActivities()
        {
            return Activities;
        }

        public Activity GetActivityById(int id)
        {
            return Activities.FirstOrDefault(a => a.Id == id);
        }

        public void CreateActivity(Activity activity)
        {
            activity.Id = Activities.Count > 0 ? Activities.Max(a => a.Id) + 1 : 1;
            Activities.Add(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            var index = Activities.FindIndex(a => a.Id == activity.Id);
            if (index != -1)
            {
                Activities[index] = activity;
            }
        }

        public void DeleteActivity(int id)
        {
            var activity = GetActivityById(id);
            if (activity != null)
            {
                Activities.Remove(activity);
            }
        }

        public void DeleteSession(int activityId, int sessionId)
        {
            var activity = GetActivityById(activityId);
            if (activity != null)
            {
                var session = activity.Sessions.FirstOrDefault(s => s.Id == sessionId);
                if (session != null)
                {
                    activity.Sessions.Remove(session);
                }
            }
        }
    }
}
