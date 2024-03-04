namespace Stepstone.Domain.Models
{
    public record Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<QuestionResponse> Responses { get; set; }
    }
}
