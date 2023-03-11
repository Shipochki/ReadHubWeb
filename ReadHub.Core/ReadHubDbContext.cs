﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Data;
using ReadHub.Core.Data.Entities;

namespace ReadHub.Core
{
    public class ReadHubDbContext : IdentityDbContext<User>
    {
        private User Admin { get; set; }

        public ReadHubDbContext(DbContextOptions<ReadHubDbContext> options)
            : base(options)
        {
            //this.Database.Migrate();
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

			this.Admin = new User()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                FirstName = "Owner",
                LastName = "Admin",
            };

            var hasher = new PasswordHasher<User>();

            this.Admin.PasswordHash =
                hasher.HashPassword(this.Admin, "admin123");

            builder
                .Entity<User>()
                .HasData(this.Admin);

            base.OnModelCreating(builder);
        }
    }
}