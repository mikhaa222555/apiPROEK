using Microsoft.EntityFrameworkCore;
namespace api
{
    public class ApplicationContext : DbContext
    {
        private object _context;
        private object Usera;

        public ApplicationContext(object id, object db) { }
        public async Task<IResult> GetUserByIds(int id) // добавили async +  Task<IResult>
        {
            User? user = await Users.FirstOrDefaultAsync(u => u.Id == id); // await работает, тк метод async
            if (user == null)
            {
                return Results.NotFound(new { message = "User not found" });
            }

            return Results.Json(user);
        }

        public async Task<IResult> GetUserById(int id)
        {

            User? user = await Users.FindAsync(id); // Исправлено: правильное название Users , чтобы соответствовало DbSet
            if (user == null) // User, а не object
            {
                return Results.NotFound(new { message = "User not found" });
            }
            return Results.Json(user);
        }
        //public User? GetUserByIds(int id)
        //{
        //    return _context.Users.Find(id);// return User или null - синхронный вызов
        //} WFFFWWFW ОШИБКА 


        //Не забывайте указать правильный DbSet:
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<User> Userss { get; set; } = null!;
        public object id { get; private set; }
        public object db { get; private set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom", Age = 37 },
                    new User { Id = 2, Name = "Bob", Age = 41 },
                    new User { Id = 3, Name = "Sam", Age = 24 }
            );
        }

    }
}
