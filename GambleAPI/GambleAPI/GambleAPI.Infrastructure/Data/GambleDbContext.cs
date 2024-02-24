using GambleAPI.GambleAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GambleAPI.GambleAPI.Infrastructure.Data
{
    public class GambleDbContext(DbContextOptions<GambleDbContext> options) : DbContext(options)
    {
        public DbSet<Player> players { get; set; }
    }
}
