using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Repositories;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Services
{

    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;
        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IResult<ProgramResponseModal>> CreateProgram(CreateProgramRequest request)
        {
            try
            {
                var program = await _programRepository.GetAnyAsync(x => x.Title == request.Title);

                if (program)
                    return await Result<ProgramResponseModal>.FailAsync("Program Title already exist", "creation_failed_99");

                var entity = new Program()
                {
                    Title = request.Title,
                    Summary = request.Summary,
                    Description = request.Description,
                    Skill = request.Skills.ToList(),
                    Benefit = request.Benefit,
                    Criteria = request.Criteria,
                    ProgramType = request.AdditionalInfo.ProgramType,
                    Start = request.AdditionalInfo.Start,
                    Open = request.AdditionalInfo.Open,
                    Close = request.AdditionalInfo.Close,
                    Location = request.AdditionalInfo.Location,
                    MinQualification = request.AdditionalInfo.MinQualification,
                    MaximumNumberOfApplication = request.AdditionalInfo.MaximumNumberOfApplication
                };

                var res = await _programRepository.AddAsync(entity);
                return Result<ProgramResponseModal>.Success(res, "sucess", "creation_successful_00");

            }
            catch(Exception ex)
            {
                return await Result<ProgramResponseModal>.FailAsync(ex.Message, "creation_failed_99");
            }
        }

        public async Task<IResult<ProgramResponseModal>> UpdateProgram(Guid Id, UpdateProgramRequest request)
        {
            try
            {
                var program = await _programRepository.GetAsync(Id);

                if (program is null)
                    return await Result<ProgramResponseModal>.FailAsync("Program Info can't be found", "update_failed_99");

                program.Title = request.Title is null ? program.Title : request.Title;
                program.Summary = request.Summary is null ? program.Summary : request.Summary;
                program.Description = request.Description is null ? program.Description : request.Description;
                program.Skill = request.Skills is null ? program.Skill : request.Skills.ToList();
                program.Benefit = request.Benefit is null ? program.Benefit : request.Benefit;
                program.Criteria = request.Criteria is null ? program.Criteria : request.Criteria;
                program.ProgramType = (Enums.ProgramType)(request.ProgramType is null ? program.ProgramType : request.ProgramType);
                program.Start = request.Start is null ? program.Start : request.Start;
                program.Open = request.Open is null ? program.Open : request.Open;
                program.Close = request.Close is null ? program.Close : request.Close;
                program.Location = request.Location is null ? program.Location : request.Location;
                program.MinQualification = (Enums.Qualification)(request.MinQualification is null ? program.MinQualification : request.MinQualification);
                program.MaximumNumberOfApplication = (long)(request.MaximumNumberOfApplication is null ? program.MaximumNumberOfApplication : request.MaximumNumberOfApplication);
                program.ModifiedOn = DateTime.UtcNow;

                var res = await _programRepository.UpdateAsync(program);
                return Result<ProgramResponseModal>.Success(res, "sucess", "update_successful_00");

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                return await Result<ProgramResponseModal>.FailAsync(ex.Message, "creation_failed_99");
            }
        }

        public async Task<IResult<ProgramResponseModal>> GetProgram(Guid Id)
        {
            try
            {
                var program = await _programRepository.GetAsync(Id);

                return Result<ProgramResponseModal>.Success(program, "sucess", "Get_successful_00");

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                return await Result<ProgramResponseModal>.FailAsync(ex.Message, "Get_failed_99");
            }
        }


    }
}
