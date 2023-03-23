using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Utilities;
using System;

namespace CapitalPlacement.Core.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IProgramRepository _programRepository;
        public ApplicationService(IApplicationRepository applicationRepository, IProgramRepository programRepository)
        {
            _applicationRepository = applicationRepository;
            _programRepository = programRepository;
        }
        public async Task<IResult<ApplicationResponseModal>> CreateApplication(Guid ProgramId, CreateApplicationRequest request)
        {
            try
            {
                var user = await _applicationRepository.GetAnyAsync(x => x.EmailAddress.Equals(request.EmailAddress));

                if (user)
                    return await Result<ApplicationResponseModal>.FailAsync("User with this email already exist", "creation_failed_99");
                
                var program = await _programRepository.GetAsync(ProgramId);
                if (program is null)
                    return await Result<ApplicationResponseModal>.FailAsync("Program with this Id not found", "creation_failed_99");

                var entity = new Application()
                {
                    CoverImage = request.CoverImage,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EmailAddress = request.EmailAddress,
                    PhoneNumber = request.PhoneNumber,
                    Nationality = request.Nationality,
                    CurrentResidence = request.CurrentResidence,
                    DateOfBirth = (DateTime)request.DateOfBirth,
                    Gender = request.Gender,
                    IdNumber = request.IdNumber,
                    ProgramId = program.Id
                };

                var res = await _applicationRepository.AddAsync(entity);
                return Result<ApplicationResponseModal>.Success(res, "sucess", "creation_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<ApplicationResponseModal>.FailAsync(ex.Message, "creation_failed_99");
            }
        }

        public async Task<IResult<ApplicationResponseModal>> UpdateApplication(string email, UpdateApplicationRequest request)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(x => x.EmailAddress.Equals(email));

                if (application is null)
                    return await Result<ApplicationResponseModal>.FailAsync("User not found", "update_failed_99");


                application.CoverImage = request.CoverImage is null ? application.CoverImage : request.CoverImage;
                application.FirstName = request.FirstName is null ? application.FirstName : request.FirstName;
                application.LastName = request.LastName is null ? application.LastName : request.LastName;
                application.CurrentResidence = request.CurrentResidence is null ? application.CurrentResidence : request.CurrentResidence;
                application.ModifiedOn = DateTime.UtcNow;


                var res = await _applicationRepository.UpdateAsync(application);
                return Result<ApplicationResponseModal>.Success(res, "sucess", "update_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<ApplicationResponseModal>.FailAsync(ex.Message, "update_failed_99");
            }
        }

        public async Task<IResult<List<ApplicationResponseModal>>> GetAllApplication()
        {
            try
            {
                var application = await _applicationRepository.GetAllAsync();

                if (application is null)
                    return await Result<List<ApplicationResponseModal>>.FailAsync("Record is empty", "get_failed_99");

                var data = application.Select(x => (ApplicationResponseModal)x).ToList();
                return Result<List<ApplicationResponseModal>>.Success(data, "sucess", "get_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<List<ApplicationResponseModal>>.FailAsync(ex.Message, "get_failed_99");
            }
        }

        public async Task<IResult<ApplicationResponseModal>> GetApplication(Guid Id)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(Id);

                if (application is null)
                    return await Result<ApplicationResponseModal>.FailAsync("Record is empty", "get_failed_99");

                return Result<ApplicationResponseModal>.Success(application, "sucess", "get_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<ApplicationResponseModal>.FailAsync(ex.Message, "get_failed_99");
            }
        }

        public async Task<IResult<bool>> DeleteApplication(Guid Id)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(Id);

                if (application is null)
                    return await Result<bool>.FailAsync("Record is empty", "get_failed_99");

                await _applicationRepository.DeleteAsync(application);

                return Result<bool>.Success("Application has been deleted successfully", "get_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<bool>.FailAsync(ex.Message, "get_failed_99");
            }
        }
    }
}
