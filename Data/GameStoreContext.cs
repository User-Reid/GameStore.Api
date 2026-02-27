using Gamestore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> context) : DbContext(context)
{
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();
}