
namespace ToDoApp.Utils
{
    public class Utilities
    {
        private Dictionary<string, Task> ToDoDictionary;
        public Utilities()
        {
            ToDoDictionary = new Dictionary<string, Task>();
        }

        public bool AddTask(string name, string description, Priority priority)
        {

            return ToDoDictionary.TryAdd(name, new Task(description, priority));

        }

        public bool CompleteTask(string name)
        {
            return ToDoDictionary.Remove(name);
        }

        public List<KeyValuePair<string,Task>> ListAllTasks()
        {
            var list =  ToDoDictionary.ToList();
            list.Sort((x, y) => x.Value.Priority.CompareTo(y.Value.Priority));
            return list;
        
         }

        public bool containsTask(string name)
        {
            return ToDoDictionary.ContainsKey(name);
        }

        public Task? GetTask(string name)
        {
            if (!containsTask(name))
            {
                return null;
            }
            return ToDoDictionary[name];

        }

        public bool EditTask(string nameBeforeEdit, string name, string description, Priority priority)
        {

            bool taskExists = ToDoDictionary.ContainsKey(nameBeforeEdit);
            if (taskExists)
            {
                if (name == null)
                {
                    Task task2 = new Task( description, priority);
                    ToDoDictionary[nameBeforeEdit].Description = description;
                    ToDoDictionary[nameBeforeEdit].Priority=priority;
                    return true;
                }
                Task task1 = new Task( description, priority);
                //ToDoDictionary.Remove(nameBeforeEdit);
                bool edited= ToDoDictionary.TryAdd(name, task1);
                if (edited)
                {
                    ToDoDictionary.Remove(nameBeforeEdit);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                return false;
            }
        }

    }
}
