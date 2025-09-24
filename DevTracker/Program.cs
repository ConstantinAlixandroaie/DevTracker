using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Data;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories;
using DevTracker.Data.Repositories.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace DevTracker.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        var configuration = builder.Configuration;
        builder.Services.AddDbContext<DevTrackerContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddMapster();
        builder.Services.AddIdentityApiEndpoints<User>()
               .AddEntityFrameworkStores<DevTrackerContext>()
               .AddDefaultTokenProviders();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        builder.Services.AddScoped<INoteRepository, NoteRepository>();
        builder.Services.AddScoped<IBoardRepository, BoardRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();

        builder.Services.AddScoped<ITaskItemService, TaskItemService>();
        builder.Services.AddScoped<INoteService, NoteService>();
        builder.Services.AddScoped<IBoardService, BoardService>();

        builder.Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }); ;
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapGroup("api/v1/Identity")
           .MapIdentityApi<User>();

        app.Run();
    }
}
