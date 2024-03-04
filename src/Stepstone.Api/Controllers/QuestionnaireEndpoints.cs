using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stepstone.Api.Core;
using Stepstone.Api.Requests;
using Stepstone.Api.Requests.Responses;
using Stepstone.Domain;
using Stepstone.Domain.Models;

namespace Stepstone.Api.Controllers
{
    [Route("api/questions")]
    public class QuestionnaireEndpoints : ApiControllerBase
    {
        private readonly IQuestionnaire _questionnaire;
        public QuestionnaireEndpoints(IMediator mediator, IQuestionnaire questionnaire) : base(mediator)
        {
            _questionnaire = questionnaire;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            List<Question>? questions = _questionnaire.GetQuestions();
            var groupedQuestions = questions.GroupBy(x => x.Title)
                .Select(g => new QuestionsResponse(
                    g.Key,
                    g.Select(q => q.Text).ToArray())).ToList();

            if (groupedQuestions.Any()) 
            { 
                return new OkObjectResult(groupedQuestions);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("advanced")]
        public IActionResult GetQuestionGuids()
        {
            List<Question>? questions = _questionnaire.GetQuestions();
            var groupedQuestions = questions.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text
            });
                

            if (groupedQuestions.Any())
            {
                return new OkObjectResult(groupedQuestions);
            }
            return NotFound();
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetQuestionById(string guid)
        {
            return await Ok(new GetQuestionByIdRequest(guid));
        }

        [HttpPost("{guid}")]
        public async Task<IActionResult> AnswerQuestion(string guid, string answer)
        {
            return await Ok(new AnswerQuestionRequest(guid, answer));
        }
    }
}
