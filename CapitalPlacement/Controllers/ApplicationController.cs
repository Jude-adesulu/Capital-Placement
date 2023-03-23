using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController<ApplicationController>
    {

        public IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET api/<ApplicationController>
        [HttpGet]
        public async Task<ActionResult> GetAllApplication()
        {
            var res = await _applicationService.GetAllApplication();
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // GET api/<ApplicationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetApplication(Guid id)
        {
            var res = await _applicationService.GetApplication(id);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // POST api/<ApplicationController>
        [HttpPost("{programId}")]
        public async Task<ActionResult> CreateApplication(Guid programId, [FromBody] CreateApplicationRequest request)
        {
            var res = await _applicationService.CreateApplication(programId, request);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // PUT api/<ApplicationController>/5
        [HttpPut("{email}")]
        public async Task<ActionResult> UpdateApplication(string email, [FromBody] UpdateApplicationRequest request)
        {
            var res = await _applicationService.UpdateApplication(email, request);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // DELETE api/<ApplicationController>/5
        [HttpDelete("{applicationId}")]
        public async Task<ActionResult> DeleteApplication(Guid applicationId)
        {
            var res = await _applicationService.DeleteApplication(applicationId);
            return ApiResponse(res.succeeded, res.message, res.message_Id);
        }
    }
}
