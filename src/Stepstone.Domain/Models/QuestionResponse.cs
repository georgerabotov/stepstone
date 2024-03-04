namespace Stepstone.Domain.Models
{
    public record QuestionResponse
    {
        public Guid QuestionId { get; set; }
        public string ResponseText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
