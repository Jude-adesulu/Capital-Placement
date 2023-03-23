using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Interfaces
{
    public interface IProgramService
    {
        Task<IResult<ProgramResponseModal>> CreateProgram(CreateProgramRequest request);
        Task<IResult<ProgramResponseModal>> UpdateProgram(Guid Id, UpdateProgramRequest request);
        Task<IResult<ProgramResponseModal>> GetProgram(Guid Id);
    }
}
