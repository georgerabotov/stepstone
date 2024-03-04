namespace Stepstone.Api.Requests.Responses
{
    public class GetQuestionByIdResponse
    {
        public GetQuestionByIdResponse(string text, string title, string[] answers)
        {
            Text = text;
            Title = title;
            Answers = answers;
        }
        public string Text { get; }
        public string Title { get; }
        public string[] Answers { get; }
    }
}
