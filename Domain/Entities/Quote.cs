namespace Domain.Entities;

public class Quote
{
    public Guid Id { get; set; } // Id, ID, QuoteId
    public required string QuoteText { get; set; }
    public Author? Author { get; set; }
    public Guid AuthorId { get; set; } //FK
}