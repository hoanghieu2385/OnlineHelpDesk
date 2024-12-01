<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

=======
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OHD_API.Models;
>>>>>>> 1b8b0fcaa8e36160a20d035239584e895dc31639
namespace OHD_API.Services
{
    public class ApplicationDBContext : IdentityDbContext
    {
<<<<<<< HEAD
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
=======
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<StatusModel> statusModels { set; get;}
        public DbSet<MediaModel> mediaModels { set; get;}
>>>>>>> 1b8b0fcaa8e36160a20d035239584e895dc31639
    }
}
