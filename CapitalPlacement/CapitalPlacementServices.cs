using Abp.Domain.Repositories;
using CapitalPlacement.Core.Interfaces;
using CapitalPlacement.Core.Repositories;
using CapitalPlacement.Core.Repositories.Interfaces;
using CapitalPlacement.Core.Services;
using Microsoft.OpenApi.Models;
using System.Collections;
using System.Reflection;
using System.Text.Json.Serialization;

namespace CapitalPlacement
{
    public static class CapitalPlacementServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            //repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IWorkflowRepository, WorkflowRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            //services
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IProgramService, ProgramService>();
            services.AddTransient<IWorkflowService, WorkflowService>();
            services.AddTransient<IPreviewService, PreviewService>();


            return services;
        }

        public static IServiceCollection AddCustomSwaggerervice(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Capital Placement Service", Description = "Capital Placement Based Services ", Version = "v1" });
                //c.EnableAnnotations();
                #region XMl Documentation  
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                #endregion
            });

            return services;
        }
    }
}
