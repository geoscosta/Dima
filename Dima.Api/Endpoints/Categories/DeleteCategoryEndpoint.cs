using System.Security.Claims;
using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("deleteCategory")
            .WithSummary("delete a category")
            .WithDescription("delete a category")
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryRequest()
        {
            UserId = user.Identity?.Name ?? string.Empty,
            CategoryId = id
        };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess 
            ? Results.Ok(result) 
            : Results.BadRequest(result);
    }
}