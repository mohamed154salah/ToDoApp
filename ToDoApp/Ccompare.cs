using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Ccompare: IComparer<Task>
    {
        public int Compare(Task? x, Task? y)
        {
            int priorityComparison = x.Priority.CompareTo(y.Priority);
            if(priorityComparison != 0)
            {
                return priorityComparison;
            }
            else
            {
                return x.Created.CompareTo(y.Created);
            }
        }
    }
   
}
