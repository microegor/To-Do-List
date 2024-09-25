using System.Collections.Generic;

namespace ToDoList
{
    internal class ToDoManager
    {
        private List<ToDoItem> items = new List<ToDoItem>();
        public void AddItem(ToDoItem item)
        {
            items.Add(item);
        }
        public void RemoveItem(ToDoItem item)
        {
            items.Remove(item);
        }
        public List<ToDoItem> GetItems()
        {
            return items;
        }
    }
}
