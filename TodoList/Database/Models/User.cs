using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Database.Models;

[Serializable]
[Table("Users", Schema = TodoDbContext.PublicScheme)]
public sealed record User
{
    [Key]
    public required Guid Id { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required string Name { get; set; }
}