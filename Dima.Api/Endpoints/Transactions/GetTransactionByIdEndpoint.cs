using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("getTransactionById")
            .WithSummary("get a transaction")
            .WithDescription("get a transaction")
            .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new GetTransactionByIdRequest()
        {
            UserId = "geo@dev.io",
            TransactionId = id
        };
        
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess 
            ? Results.Ok(result) 
            : Results.BadRequest(result);
    }
}