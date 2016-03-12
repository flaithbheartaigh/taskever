using Taskever.Tasks;

namespace Taskever.Activities
{
    public class CompleteTaskActivity : Activity
    {

        public CompleteTaskActivity()
        {
            // ActivityType = ActivityType.CompleteTask;            
        }

        public override long?[] GetActors()
        {
            return new[] { (long?)AssignedUserId };
        }

        public override long?[] GetRelatedUsers()
        {
            return new[] {Task.CreatorUserId};
        }
    }
}