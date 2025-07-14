namespace Src.Domain.Dto
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoText { get; set; } // Nota: el nombre original es "todo"
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}