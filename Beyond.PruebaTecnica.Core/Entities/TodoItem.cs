namespace Beyond.PruebaTecnica.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<Progression> Progressions { get; set; }
        public decimal? TotalProgression => Progressions?.Sum(p => p.Percent);
        public bool IsCompleted => Progressions?.Sum(p => p.Percent) >= 100;

        public TodoItem(int id, string title, string description, string category)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Progressions = new List<Progression>();
        }

        public void AddProgression(Progression progression)
        {

            if (Progressions.Any(p => p.Date >= progression.Date))
                throw new InvalidOperationException("Progression date must be later than previous ones.");

            if (progression.Percent <= 0 || progression.Percent >= 100)
                throw new InvalidOperationException("Progression percent must be between 0 and 100.");

            decimal totalPercent = Progressions.Sum(p => p.Percent) + progression.Percent;
            if (totalPercent > 100)
                throw new InvalidOperationException("Total progress cannot exceed 100%.");

            Progressions.Add(progression);
        }
    }
}
