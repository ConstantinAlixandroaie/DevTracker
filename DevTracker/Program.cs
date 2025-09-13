using DevTracker.Application.Services;
using DevTracker.Data;
using DevTracker.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.AddScoped<ITaskItemService, TaskItemService>();
        builder.Services.AddScoped<INoteService, NoteService>();
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<DevTrackerContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                
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
