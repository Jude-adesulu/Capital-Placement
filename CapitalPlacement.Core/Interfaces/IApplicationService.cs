using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Interfaces
{
    public interface IApplicationService
    {
        Task<IResult<ApplicationResponseModal>> CreateApplication(Guid ProgramId, CreateApplicationRequest request);
        Task<IResult<ApplicationResponseModal>> UpdateApplication(string email, UpdateApplicationRequest request);
        Task<IResult<List<ApplicationResponseModal>>> GetAllApplication();
        Task<IResult<ApplicationResponseModal>> GetApplication(Guid Id);
        Task<IResult<bool>> DeleteApplication(Guid Id);
    }
}
