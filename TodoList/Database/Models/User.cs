using System.ComponentModel.DataAnnotations;

namespace TodoList.Database.Models;

public sealed record User
{
    [Key]
    public required Guid Id { get; set; }
    
    public required DateTimeOffset CreatedAt { get; set; }
}