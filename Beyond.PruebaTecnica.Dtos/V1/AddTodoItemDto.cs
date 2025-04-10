namespace Beyond.PruebaTecnica.Dtos.V1
{
    public class AddTodoItemDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
    }

}
