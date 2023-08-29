
namespace ToDoApp
{
    public class Task
    {
        private string description = string.Empty;
        private DateTime created;
        private Priority priority;
        private bool isComplete;
        public Task( string description, Priority priority)
        {
            this.description = description;
            this.priority = priority;
            created = DateTime.Now;
            isComplete = false;
        }
   
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Priority Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public bool IsComplete
        {
            get { return isComplete; }
            set { isComplete = value; }

        }
        public DateTime Created
        {
            get { return created; }
        }

       
    }
}
