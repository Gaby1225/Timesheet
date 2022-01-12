using Microsoft.EntityFrameworkCore;
using Timesheet.Domain.Models;

namespace Timesheet.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
