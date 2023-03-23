using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : BaseController<WorkflowController>
    {
        public IWorkflowService _workflowService;

        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }
        // GET: api/<WorkflowController>
        [HttpGet]
        public async Task<ActionResult> GetAllStages()
        {
            var res = await _workflowService.GetAll();
            return ApiResponse(res.data, res.succeeded, res.message);
        }

        // GET api/<WorkflowController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStage(Guid id)
        {
            var res = await _workflowService.GetStage(id);
            return ApiResponse(res.data, res.succeeded, res.message);
        }

        // POST api/<WorkflowController>
        [HttpPost]
        public async Task<ActionResult> CresteStage([FromBody] CreateStageRequest request)
        {
            var res = await _workflowService.CreateStage(request);
            return ApiResponse(res.data, res.succeeded, res.message);
        }

        // PUT api/<WorkflowController>/5
        [HttpPut]
        public async Task<ActionResult> UpdateState([FromBody] UpdateStageRequest request)
        {
            var res = await _workflowService.UpdateStage(request);
            return ApiResponse(res.succeeded, res.message);
        }

        // DELETE api/<WorkflowController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStage(Guid id)
        {
            var res = await _workflowService.DeleteStage(id);
            return ApiResponse(res.data, res.succeeded, res.message);
        }
    }
}
