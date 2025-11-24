namespace Dima.Core.Requests.Transactions;

public class GetTransactionByIdRequest : Request
{
    public long TransactionId { get; set; }
}