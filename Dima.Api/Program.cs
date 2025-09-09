using Dima.Api.Data;
using Dima.Core.Enums;
using Dima.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connection);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    "/v1/categories", 
    (Request request, Handler handler) => handler.Handle(request)).Produces<Response>();

app.Run();

// Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    // public DateTime CreatedAt { get; set; } = DateTime.Now;
    // public ETransactionType TypeTransaction { get; set; } = ETransactionType.Withdraw;
    // public decimal Amount { get; set; }
    // public long CategoryId { get; set; }
    // public string UserId { get; set; }  =  string.Empty;
}

// Response
public class Response
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    // public DateTime CreatedAt { get; set; }
    // public DateTime? PaidOrReceivedAt { get; set; }
    // public ETransactionType TypeTransaction { get; set; }
    // public decimal Amount { get; set; }
    // public long CategoryId { get; set; }
    // public Category Category { get; set; } = null!;
    // public string UserId { get; set; }  =  string.Empty;
}

// Handler
public class Handler(AppDbContext context)
{
    public Response Handle(Request req)
    {
        var category = new Category
        {
            Title = req.Title,
            Description = req.Description
        };
        
        context.Categories.Add(category);
        context.SaveChanges();
        
        return new Response
        {
            Id = category.Id,
            Title = category.Title,
        };
    }
    
}
