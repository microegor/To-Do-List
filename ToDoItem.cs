using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDoItem
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
        public DateTime CreationDate { get; set; } 
        public PriorityLevel Priority { get; set; }
    }
}
