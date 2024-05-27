using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Database.Models;

[Serializable]
[Table("Todos", Schema = TodoDbContext.PublicScheme)]
[EntityTypeConfiguration<TodoConfigure, Todo>]
public sealed record Todo
{
    [Key]
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
    public required DateTimeOffset ExecutionDate { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required bool IsDeleted { get; set; }
    public required User User { get; set; }
}

file sealed class TodoConfigure : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}