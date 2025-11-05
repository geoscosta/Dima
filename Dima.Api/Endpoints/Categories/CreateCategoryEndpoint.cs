using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("CreateCategory")
            .WithSummary("Creates a new category")
            .WithDescription("Creates a new category")
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
    {
        request.UserId = "geo@dev.io";
        
        var result = await handler.CreateAsync(request);
        return result.IsSuccess 
            ? Results.Created($"/{result.Data?.Id}", result) 
            : Results.BadRequest(result);
    }
}