namespace Dima.Core.Models;

public class Category
{
    public long Id { get; set; }
    public string Title { get; set; } =  String.Empty;
    public string Description { get; set; } = String.Empty;
    public string UserId { get; set; } =  String.Empty; 
} 