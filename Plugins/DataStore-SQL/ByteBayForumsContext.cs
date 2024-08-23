using CoreBusiness;
using CoreBusiness.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataStore_SQL
{
    public class ByteBayForumsContext : DbContext
    {

        // remember to always migrate your changes :)


        public ByteBayForumsContext(DbContextOptions<ByteBayForumsContext> options) : base(options)
        {


        }

        //what tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(category => category.Posts)
                .WithOne(post => post.Category)
                .HasForeignKey(post => post.CategoryId);




            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Web Dev", Description = "Web Development" },
                new Category { CategoryId = 2, Name = "Embedded Systems", Description = "Embedded Systems" },
                new Category { CategoryId = 3, Name = "Cyber Security", Description = "Cyber Security" }
            );

            modelBuilder.Entity<Post>().HasData(
             new Post
             {
                 PostId = 1,
                 CategoryId = 1,
                 Subject = "Cloudinary API for NEXT.js",
                 Content = "How do I approach implementing cloudinary API into my profile section",
                 Flag = PostFlags.None
             },
            new Post
            {
                PostId = 2,
                CategoryId = 1,
                Subject = "ASP.Net",
                Content = "Is it true that dotnet developers make big bucks",
                Flag = PostFlags.None
            },
            new Post
            {
                PostId = 3,
                CategoryId = 2,
                Subject = "Road map for beginners",
                Content = "where do i start with embedded programming?",
                Flag = PostFlags.None
            },
            new Post
            {
                PostId = 4,
                CategoryId = 2,
                Subject = "Programming my STM32 Board",
                Content = "anyone knows a good source to get this microcontroller? Have been " +
                "searching around but no luck",
                Flag = PostFlags.None
            }
         );

        }
    }
}
