using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));



        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);

        services.AddTransient<IAnswerService, AnswerService>();
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IQuestionService, QuestionService>();
        services.AddTransient<IQuestionsBaseService, QuestionsBaseService>();
        services.AddTransient<IQuestionsGroupService, QuestionsGroupService>();
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<ISubjectService, SubjectService>();
        services.AddTransient<ITestService, TestService>();
        services.AddTransient<IUniversityService, UniversityService>();
        
        
        return services;
    }
}