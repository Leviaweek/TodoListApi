using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Database.Models;

[Serializable]
[Table("TelegramUsers", Schema = TodoDbContext.PublicScheme)]
[EntityTypeConfiguration<TelegramUsersConfigure, TelegramUser>]
[Index(nameof(TelegramUserId), IsUnique = true)]
public sealed record TelegramUser
{
    [Key] public required Guid UserId { get; set; }
    public required long TelegramUserId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required User User { get; set; }
}
file sealed class TelegramUsersConfigure : IEntityTypeConfiguration<TelegramUser>
{
    public void Configure(EntityTypeBuilder<TelegramUser> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<TelegramUser>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}