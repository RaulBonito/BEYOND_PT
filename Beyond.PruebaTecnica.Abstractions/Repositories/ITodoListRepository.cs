using Beyond.PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.PruebaTecnica.Abstractions.Repositories
{
    public interface ITodoListRepository
    {
        int GetNextId();
        List<string> GetAllCategories();
        List<TodoItem> GetAllItems();
        TodoItem GetById(int id);
        void Save(TodoItem item);
        void Remove(int id);
    }
}
