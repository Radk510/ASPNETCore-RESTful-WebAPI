using CommandWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandWebApi.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options)
            : base(options)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}