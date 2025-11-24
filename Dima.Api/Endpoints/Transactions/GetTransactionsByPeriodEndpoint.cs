using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("getalltransactions")
            .WithSummary("get all transactions")
            .WithDescription("get all transactions")
            .Produces<PagedResponse<List<Transaction>?>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, 
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTransactionByPeriodRequest()
        {
            UserId = "geo@dev.io",
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };
        
        var result = await handler.GetByPeriodAsync(request);
        return result.IsSuccess 
            ? Results.Ok(result) 
            : Results.BadRequest(result);
    }
}