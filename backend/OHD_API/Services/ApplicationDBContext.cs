﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OHD_API.Models;
namespace OHD_API.Services
{
    public class ApplicationDBContext : IdentityDbContext
    {
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
        public DbSet<StatusModel> Statuses { set; get;}
        public DbSet<MediaTypeModel> MediaTypes { set; get;}
        public DbSet<MediaModel> Media { get; set; }
        public DbSet<FacilityModel> Facilities { get; set; }
        public DbSet<RequestModel> Requests { get; set; }

    }
}
