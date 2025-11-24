using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("UpdateTransaction")
            .WithSummary("update a transaction")
            .WithDescription("update a transaction")
            .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionRequest request, long id)
    {
        request.UserId = "geo@dev.io";
        request.CategoryId = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess 
            ? Results.Ok(result) 
            : Results.BadRequest(result);
    }
}