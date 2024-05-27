using Microsoft.EntityFrameworkCore;
using TodoList.Database.Models;

namespace TodoList.Database;

[Serializable]
public class TodoDbContext(DbContextOptions<TodoDbContext> options): DbContext(options)
{
    public const string PublicScheme = "public";
    
    public required DbSet<User> Users { get; set; }
    public required DbSet<Todo> Todos { get; set; }
    public required DbSet<WebUser> WebUsers { get; set; }
    public required DbSet<TelegramUser> TelegramUsers { get; set; }
}