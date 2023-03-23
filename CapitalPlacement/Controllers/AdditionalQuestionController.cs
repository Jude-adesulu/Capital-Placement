using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalQuestionController : BaseController<AdditionalQuestionController>
    {
        public IAdditionQuestion _AdditionalQuestion;
        public AdditionalQuestionController(IAdditionQuestion additionalQuestion)
        {
            _AdditionalQuestion = additionalQuestion;
        }

        // POST api/<AdditionalQuestionController>
        [HttpPost("{applicationId}")]
        public async Task<ActionResult> Post(Guid applicationId, [FromBody] AdditionalQuestionRequest request)
        {
            var res = await _AdditionalQuestion.CreateApplication(applicationId, request);
            return ApiResponse(res.data, res.succeeded, res.message);
        }
    }
}
