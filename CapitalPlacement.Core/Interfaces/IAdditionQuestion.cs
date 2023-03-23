using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using System;
namespace CapitalPlacement.Core.Interfaces
{
    public interface IAdditionQuestion
    {
        Task<IResult<AddtionalQuestionResponseModal>> CreateApplication(Guid applicationId, AdditionalQuestionRequest request);
    }
}
