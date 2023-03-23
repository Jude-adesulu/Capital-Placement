using CapitalPlacement.Core.DTOs.Requests;
using CapitalPlacement.Core.DTOs.Responses;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Utilities;
using System;

namespace CapitalPlacement.Core.Services
{
    public class AdditionalQuestions : IAdditionQuestion
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IQuestionRepository _questionRepository;

        public AdditionalQuestions(IApplicationRepository applicationRepository, IQuestionRepository questionRepository)
        {
            _applicationRepository = applicationRepository;
            _questionRepository = questionRepository;
        }

        public async Task<IResult<AddtionalQuestionResponseModal>> CreateApplication(Guid applicationId, AdditionalQuestionRequest request)
        {
            var question = new AdditionalQuestion();
            try
            {
                var app = await _applicationRepository.GetAsync(x => x.Id.Equals(applicationId));

                if (app is null)
                    return await Result<AddtionalQuestionResponseModal>.FailAsync("Application does not exist", "create_failed_99");

                question.ApplicationId = applicationId;
                question.Content = request.Content;
                switch (request.QuestionsType.ToString())
                {
                    case "DateQuestion":
                        question.DateQuestion = request.QuestionsType.DateQuestion;
                        break;

                    case "YesOrNoQuestion":
                        question.YesOrNoQuestion = request.QuestionsType.YesOrNoQuestion;
                        break;

                    case "ParagraphQuestion":
                        question.YesOrNoQuestion = request.QuestionsType.YesOrNoQuestion;
                        break;
                    case "FileUploadQuestion":
                        question.FileUploadQuestion = request.QuestionsType.FileUploadQuestion;
                        break;
                    case "NumberQuestion":
                        question.NumberQuestion = request.QuestionsType.NumberQuestion;
                        break;
                    case "MultipleChoiceQuestion":
                        question.MultipleChoiceQuestion = request.QuestionsType.MultipleChoiceQuestion;
                        break;
                    case "DropdownQuestion":
                        question.DropdownQuestion = request.QuestionsType.DropdownQuestion;
                        break;
                    case "VideoBasedQuestion":
                        question.VideoBasedQuestion = request.QuestionsType.VideoBasedQuestion;
                        break;
                }
                 var result = await _questionRepository.AddAsync(question);
                return Result<AddtionalQuestionResponseModal>.Success(result, "sucess", "creation_successful_00");

            }
            catch (Exception ex)
            {
                return await Result<AddtionalQuestionResponseModal>.FailAsync(ex.Message, "creation_failed_99");
            }
        }
    }
}
