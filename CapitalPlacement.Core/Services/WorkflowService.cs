using Azure.Core;
using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Models.Stages;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Utilities;
using System;
using static CapitalPlacement.Core.Utilities.Enums;

namespace CapitalPlacement.Core.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;

        public WorkflowService(IWorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }

        public async Task<IResult<string>> CreateStage(CreateStageRequest request)
        {
            
            try
            {
                var stage = await _workflowRepository.GetAsync(x => x.StageName.Equals(request.StageName));

                if (stage is not null && stage.StageType != StageType.VideoInterview)
                    return await Result<string>.FailAsync("Stage name already exist", "create_failed_99");

                if (stage.StageType.Equals(StageType.VideoInterview) && stage.VideoInterviews.Count <= 3)
                {
                    stage.VideoInterviews.AddRange(request.VideoInterviews);

                    if (stage.VideoInterviews.Count > 3)
                    return await Result<string>.FailAsync("Video Interview can't be more than 3", "create_failed_99");

                    await _workflowRepository.UpdateAsync(stage);
                }

                switch (request.StageType.ToString())
                {
                    case "VideoInterview":
                        var addStage = new Stage
                        {
                            StageName = request.StageName,
                            StageType = request.StageType,

                            VideoInterviews = request.VideoInterviews.Select(question => new VideoInterviewQuestion
                            {
                                Question = question.Question,
                                Description = question.Description,
                                MaxDuration = question.MaxDuration,
                                VideoDuration = question.VideoDuration,
                                DeadlineInNumberOfDays = question.DeadlineInNumberOfDays,

                            }).ToList()
                        };
                        var res = await _workflowRepository.AddAsync(addStage);
                        if (res is not null)
                            return Result<string>.Success("Stage created successfully", "create_success_00");
                        else
                            return Result<string>.Fail();
                    default:
                        addStage = new Stage
                        {
                            StageName = request.StageName,
                            StageType = request.StageType,
                        };
                         res = await _workflowRepository.AddAsync(addStage);
                        if (res is not null)
                            return Result<string>.Success("Stage created successfully", "create_success_00");
                        else
                            return Result<string>.Fail();
                }

            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message, "create_failed_99");
            }

        }

        public async Task<IResult<string>> UpdateStage(UpdateStageRequest request)
        {
            try
            {
                var stage = await _workflowRepository.GetAsync(x => x.StageName.Equals(request.StageName));

                if (stage is null)
                    return await Result<string>.FailAsync("Stage not found", "update_failed_99");

                stage.StageName = request.StageName is null ? stage.StageName : request.StageName;
                stage.StageType = (StageType)(request.StageType is null ? stage.StageType : request.StageType);

                if (request.VideoInterviews is null)
                {
                    if (stage.StageType.Equals(StageType.VideoInterview) && stage.VideoInterviews.Count <= 3)
                    {
                        stage.VideoInterviews.AddRange(request.VideoInterviews);

                        if (stage.VideoInterviews.Count > 3)
                            return await Result<string>.FailAsync("Video Interview can't be more than 3", "update_failed_99");
                    }
                }

                await _workflowRepository.UpdateAsync(stage);

                return Result<string>.Success("Stage updated successfully", "update_success_00");
            }
            catch (Exception ex)
            {
                return Result<string>.Success("Stage updated successfully", "update_success_00");

            }
        }

        public async Task<IResult<WorkflowResponseModal>> GetStage(Guid Id)
        {
            var stage = await _workflowRepository.GetAsync(x => x.Id.Equals(Id));

            if (stage is null)
                return await Result<WorkflowResponseModal>.FailAsync("Stage not found", "get_failed_99");

            return Result<WorkflowResponseModal>.Success(stage, "success", "get_success_00");
        }

        public async Task<IResult<List<WorkflowResponseModal>>> GetAll()
        {
            try
            {
                var result = await _workflowRepository.GetAllAsync();

                return Result<List<WorkflowResponseModal>>.Success((List<WorkflowResponseModal>)result, "sucess", "get_success_00");
            }
            catch (Exception ex)
            {
                return await Result<List<WorkflowResponseModal>>.FailAsync(ex.Message, "get_fail_00");
            }

        }

        public async Task<IResult<string>> DeleteStage(Guid Id)
        {
            try
            {
                var stage = await _workflowRepository.GetAsync(x => x.Id.Equals(Id));

                if (stage is null)
                    return await Result<string>.FailAsync("Stage not found", "delete_failed_99");

                await _workflowRepository.DeleteAsync(stage);

                return Result<string>.Success("Stage deleted successfully", "delete_success_00");

            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message, "delete_failed_99");
            }
        }


    }
}
