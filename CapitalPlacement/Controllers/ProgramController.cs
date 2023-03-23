using Azure.Core;
using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : BaseController<ProgramController>
    {
        public IProgramService _programService;
        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        // GET api/<ProgramController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProgram(Guid id)
        {
            var res = await _programService.GetProgram(id);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // POST api/<ProgramController>
        [HttpPost]
        public async Task<ActionResult> CreateProgram([FromBody] CreateProgramRequest request)
        {
            var res = await _programService.CreateProgram(request);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }

        // PUT api/<ProgramController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateProgramRequest request)
        {
            var res = await _programService.UpdateProgram(id, request);
            return ApiResponse(res.data, res.succeeded, res.message, res.message_Id);
        }
    }
}
