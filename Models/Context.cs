using Microsoft.EntityFrameworkCore;
namespace ChefsNDishes.Models
{
    public class MenuContext: DbContext
    {
        // base(options) calls the parent class's constructor
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) {}
        public DbSet<Dish> Dishes {get; set;}
        public DbSet<Chef> Chefs {get; set;}
    }
}