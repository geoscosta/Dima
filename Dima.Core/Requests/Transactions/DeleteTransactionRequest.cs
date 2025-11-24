namespace Dima.Core.Requests.Transactions;

public class DeleteTransactionRequest : Request
{
    public long TransactionId { get; set; }
}