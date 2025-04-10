using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWebApplication.Shared.Models
{
    public class TodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    public class AddTodoItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    public class RegisterProgressionDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Percent { get; set; }
    }

    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? TotalProgression { get; set; }
        public bool IsCompleted { get; set; }
        public List<ProgressionDto> Progressions { get; set; }
    }
    public class ProgressionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Percent { get; set; }
    }

}
