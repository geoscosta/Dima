using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("deleteTransaction")
            .WithSummary("delete a transaction")
            .WithDescription("delete a transaction")
            .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new DeleteTransactionRequest()
        {
            UserId = "geo@dev.io",
            TransactionId = id
        };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess 
            ? Results.Ok(result) 
            : Results.BadRequest(result);
    }
}