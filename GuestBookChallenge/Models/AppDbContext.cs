using Microsoft.EntityFrameworkCore;

namespace GuestBookChallenge.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User { Id = 1, Name = "Mohamed", UserName = "Mohamed", Password = "123456" },
                new User { Id = 2, Name = "Mostafa", UserName = "Mostafa", Password = "123456" },
                new User { Id = 3, Name = "Mahmoud", UserName = "Mahmoud", Password = "123456" }
                );

            modelBuilder.Entity<Message>()

                           .HasData(
                           new Message { Id = 1, Title = "first", Body = "Some random text ", UserId = 1 },
                           new Message { Id = 2, Title = "sec", Body = "Some random text ", UserId = 1 },
                           new Message { Id = 3, Title = "third", Body = "Some random text ", UserId = 1 },
                           new Message { Id = 4, Title = "first", Body = "Some random text ", UserId = 2 },
                           new Message { Id = 5, Title = "sec", Body = "Some random text ", UserId = 2 },
                           new Message { Id = 6, Title = "third", Body = "Some random text ", UserId = 2 },
                           new Message { Id = 7, Title = "first", Body = "Some random text ", UserId = 3 },
                           new Message { Id = 8, Title = "sec", Body = "Some random text ", UserId = 3 },
                           new Message { Id = 9, Title = "third", Body = "Some random text ", UserId = 3 }
                           );
            modelBuilder.Entity<Reply>()
               .HasData(
               new Reply { Id = 1, Body = "Some random reply ", UserId = 1, MessageId = 1 },
               new Reply { Id = 2, Body = "Some random  reply", UserId = 1, MessageId = 2 },
               new Reply { Id = 3, Body = "Some random reply ", UserId = 1, MessageId = 3 },
               new Reply { Id = 4, Body = "Some random reply ", UserId = 2, MessageId = 4 },
               new Reply { Id = 5, Body = "Some random  reply", UserId = 2, MessageId = 5 },
               new Reply { Id = 6, Body = "Some random reply ", UserId = 2, MessageId = 6 },
               new Reply { Id = 7, Body = "Some random reply ", UserId = 3, MessageId = 7 },
               new Reply { Id = 8, Body = "Some random  reply", UserId = 3, MessageId = 8 },
               new Reply { Id = 9, Body = "Some random reply ", UserId = 3, MessageId = 9 }
               );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replys { get; set; }

    }
}
