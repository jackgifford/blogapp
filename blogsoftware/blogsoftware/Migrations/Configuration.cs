using System.Collections.Generic;
using blogsoftware.Models;

namespace blogsoftware.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<blogsoftware.Context.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(blogsoftware.Context.AppContext context)
        {

            var userBlogs = new List<Post>
            {
                new Post {Body = "Test1", Title = "Test1"},
                new Post {Body = "Test2", Title = "Test2"},
                new Post {Body = "Test3", Title = "Test3"},
                new Post {Body = "Test4", Title = "Test4"}
            };

            context.Users.Add(
                new User { Username = "Admin", PasswordHash = "Admin", Posts = userBlogs });

            context.SaveChanges();

            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
