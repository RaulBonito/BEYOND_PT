using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.PruebaTecnica.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();
        private readonly List<string> _categories = new List<string> { "Work", "Personal", "Study" };

        public int GetNextId() => _items.Any() ? _items.Max(x => x.Id) + 1 : 1;


        public List<string> GetAllCategories() => _categories;

        public TodoItem GetById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id) !;
        }

        public void Save(TodoItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == item.Id);

            if (existing != null)
                _items.Remove(existing);

            _items.Add(item);
        }

        public void Remove(int id)
        {
            var item = GetById(id);
            if (item != null) _items.Remove(item);
        }

        public List<TodoItem> GetAllItems()
        {
            return _items;
        }
    }
}
