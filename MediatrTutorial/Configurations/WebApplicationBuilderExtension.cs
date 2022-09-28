using FluentValidation.AspNetCore;

namespace MediatrTutorial.Configurations;

public static class WebApplicationBuilderExtension
{
    /// <summary>
    /// Add swagger configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        // string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        // string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();

            options.SwaggerDoc("v1", new OpenApiInfo { Title = "MediatR Tutorial API", Version = "v1" });

            // options.IncludeXmlComments(xmlPath);
        });
    }

    /// <summary>
    /// Add database configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddDatabaseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<MediatrTutorialDbContext>(option =>
        {
            option.UseInMemoryDatabase("mediatr_tutorial_db");

            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            option.LogTo(Console.WriteLine);
        });
    }

    /// <summary>
    /// Add mediatr and services
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMediatrConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
    }

    /// <summary>
    /// Add Controller configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddControllerConfiguration(this WebApplicationBuilder builder)
    {
        static void MvcOptions(MvcOptions options)
        {
            options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
            options.ReturnHttpNotAcceptable = true;
        }

        static void JsonOptions(JsonOptions options)
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }

        static void ValidatorOptions(FluentValidationMvcConfiguration options)
        {
            options.RegisterValidatorsFromAssemblyContaining<Program>();
        }

        builder.Services.AddControllers(MvcOptions).AddJsonOptions(JsonOptions).AddFluentValidation(ValidatorOptions);
    }

    /// <summary>
    /// Add cors configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddCorsConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        });
    }
}