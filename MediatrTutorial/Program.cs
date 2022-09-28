var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseConfiguration();

builder.AddMediatrConfiguration();

builder.AddControllerConfiguration();

builder.AddSwaggerConfiguration();

builder.AddCorsConfiguration();

var application = builder.Build();

application.UseMiddleware<ExceptionHandlerFilter>();

// application.UseDeveloperExceptionPage();

application.UseSwagger();

application.UseSwaggerUI();

application.UseHttpsRedirection();

application.MapControllers();

application.Run();