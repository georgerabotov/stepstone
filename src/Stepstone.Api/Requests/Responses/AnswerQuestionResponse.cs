namespace Stepstone.Api.Requests.Responses
{
    public class AnswerQuestionResponse
    {
        public AnswerQuestionResponse(bool iscorrect, string text)
        {
            IsCorrect = iscorrect;
            Text = text;
        }
        public bool IsCorrect { get; }
        public string Text { get; }
    }
}
