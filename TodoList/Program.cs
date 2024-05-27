using Microsoft.EntityFrameworkCore;
using TodoList.Abstractions;
using TodoList.Database;
using TodoList.Handlers;
using TodoList.Mediators;
using TodoList.Models.Commands;
using TodoList.Models.Queries;
using TodoList.Models.Responses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<TodoDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IQueryMediator, QueryMediator>();
builder.Services.AddSingleton<ICommandMediator, CommandMediator>();
builder.Services.AddTransient<IQueryHandler<GetAllTodoQuery, GetAllTodoQueryResponse>, GetAllTodoQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetTodoQuery, GetTodoQueryResponse>, GetTodoQueryHandler>();
builder.Services.AddTransient<ICommandHandler<AddTodoCommand, AddTodoCommandResponse>, AddTodoCommandHandler>();
builder.Services
    .AddTransient<ICommandHandler<UpdateTodoCommand, UpdateTodoCommandResponse>, UpdateTodoCommandHandler>();
builder.Services
    .AddTransient<ICommandHandler<DeleteTodoCommand, DeleteTodoCommandResponse>, DeleteTodoCommandHandler>();
builder.Services
    .AddTransient<ICommandHandler<AddWebUserCommand, AddWebUserCommandResponse>, AddWebUserCommandHandler>();
builder.Services
    .AddTransient<ICommandHandler<LoginWebUserCommand, LoginWebUserCommandResponse>, LoginWebUserCommandHandler>();



var app = builder.Build();

app.UseRouting();
app.UseCors();
app.MapControllers();

await app.RunAsync();