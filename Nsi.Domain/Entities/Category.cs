namespace Nsi.Domain.Entities;

public class Category
{
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public ApplicationUser User { get; set; }
    
    public Guid Id { get; set; }
}