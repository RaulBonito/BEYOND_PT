using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Core.Entities;


namespace Beyond.PruebaTecnica.Services
{
    public class TodoListService : ITodoList
    {
        private readonly ITodoListRepository _repository;

        public TodoListService(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public void AddItem(int id, string title, string description, string category)
        {
            if (!_repository.GetAllCategories().Contains(category))
                throw new InvalidOperationException("Invalid category.");

            var item = new TodoItem(id, title, description, category);
            _repository.Save(item);
        }

        public void UpdateItem(int id, string description)
        {
            var item = _repository.GetById(id) ?? throw new ArgumentException("Item not found.");

            if (item.TotalProgression >= 50)
            {
                throw new InvalidOperationException("Cannot update items over 50% progress.");
            }

            item.Description = description;

            _repository.Save(item);
        }

        public void RemoveItem(int id)
        {
            var item = _repository.GetById(id) ?? throw new ArgumentException("Item not found.");

            if (item.TotalProgression >= 50)
            {
                throw new InvalidOperationException("Cannot remove items over 50% progress.");
            }

            _repository.Remove(id);
        }


        public void RegisterProgression(int id, DateTime dateTime, decimal percent)
        {
            var item = _repository.GetById(id) ?? throw new ArgumentException("Item not found.");

            var progression = new Progression(dateTime, percent);

            item.AddProgression(progression);

            _repository.Save(item);
        }

        public void PrintItems()
        {
            var items = _repository.GetAllItems().OrderBy(x => x.Id).ToList();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}) {item.Title} - {item.Description} ({item.Category}) Completed: {item.IsCompleted}");

                decimal acumulado = 0;
                foreach (var prog in item.Progressions.OrderBy(p => p.Date))
                {
                    acumulado += prog.Percent;
                    int barraTotal = 50; // longitud total de la barra
                    int charsLlenos = (int)(acumulado / 100 * barraTotal);
                    string barra = new string('X', charsLlenos).PadRight(barraTotal, '_');
                    Console.WriteLine($"{prog.Date:G} - {acumulado}% \t |{barra}|");
                }

                Console.WriteLine(); // línea en blanco entre items
            }
        }
    }
}
