using DevTracker.Application.Services;

namespace DevTracker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.AddScoped<ITaskItemService, TaskItemService>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                });
            }
            app.MapControllers();

            app.Run();
        }
    }
}
