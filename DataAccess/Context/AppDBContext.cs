using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
       
        public AppDBContext(DbContextOptions<AppDBContext> options)
       : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Role>().HasData(
        //        new Role
        //        {
        //            ID = 1,
        //            Name = "Admin",
        //            Create = DateTime.Now,
        //        });

        //    modelBuilder.Entity<Role>().HasData(
        //        new Role
        //        {
        //            ID = 2,
        //            Name = "User",
        //            Create = DateTime.Now,
        //        }
        //        );

        //    var salt = Crypto.GenerateSalt();

        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            ID = 1,
        //            ImageURL = "men.png",
        //            PopularIcon = true,
        //            UserName = "Admin",
        //            Salt = salt,
        //            PasswordHash = Crypto.GenerateSHA256Hash("Admin123", salt),
        //            RoleId = 1,
        //            Create = DateTime.Now,
        //        }
        //        );
        //}
    }
}
