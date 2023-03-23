using CapitalPlacement.Core.DTOs.Responses;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Utilities;
using System;

namespace CapitalPlacement.Core.Services
{
    public class PreviewService : IPreviewService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IProgramRepository _programRepository;

        public PreviewService(IApplicationRepository applicationRepository, IProgramRepository programRepository)
        {
            _applicationRepository = applicationRepository;
            _programRepository = programRepository;
        }

        public async Task<IResult<PreviewResponseModal>> GetPreview(string title)
        {
            try
            {
                var program = await _programRepository.GetAsync(x => x.Title.Equals(title));
                if (program is null)
                    return Result<PreviewResponseModal>.Fail("Program cant be found","preview_fail_99");

                var application = await _applicationRepository.GetAsync(x => x.ProgramId.Equals(program.Id));

                var result = new PreviewResponseModal
                {
                    CoverImage = application.CoverImage,
                    Title = program.Title,
                    Summary = program.Summary,
                    Description = program.Description,
                    Skills = program.Skill.ToList(),
                    Benefit = program.Benefit,
                    Criteria = program.Criteria,
                    ProgramType = program.ProgramType,
                    Start = program.Start,
                    Open = program.Open,
                    Close = program.Close,
                    Duration = program.Duration,
                    Location = program.Location
                };

                return Result<PreviewResponseModal>.Success(result, "success", "preview_success_00");
            }
            catch (Exception ex)
            {
                return Result<PreviewResponseModal>.Fail(ex.Message, "preview_failed_99");
            }
        }
    }
}
