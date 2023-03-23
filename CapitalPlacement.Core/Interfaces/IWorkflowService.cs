using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Interfaces
{
    public interface IWorkflowService
    {
        Task<IResult<string>> CreateStage(CreateStageRequest request);
        Task<IResult<string>> UpdateStage(UpdateStageRequest request);
        Task<IResult<List<WorkflowResponseModal>>> GetAll();
        Task<IResult<WorkflowResponseModal>> GetStage(Guid Id);
        Task<IResult<string>> DeleteStage(Guid Id);
    }
}
