namespace Src.Domain.Dto
{
    public class TodoResponse
    {
        public List<Todo> Todos { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}