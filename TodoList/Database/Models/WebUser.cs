using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Database.Models;

[Serializable]
[Table("WebUsers", Schema = TodoDbContext.PublicScheme)]
[EntityTypeConfiguration<WebUserConfigure, WebUser>]
[Index(nameof(Login), IsUnique = true)]
public sealed record WebUser
{
    [Key] public required Guid UserId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required User User { get; set; }
}

file sealed class WebUserConfigure : IEntityTypeConfiguration<WebUser>
{
    public void Configure(EntityTypeBuilder<WebUser> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<WebUser>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}