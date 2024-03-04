namespace Stepstone.Api.Requests.Responses
{
    public record QuestionsResponse
    {
        public QuestionsResponse(string title, string[] questionsText)
        {
            Title = title;
            QuestionsText = questionsText;
        }
        public string Title { get; }
        public string[] QuestionsText { get; }
    }
}
