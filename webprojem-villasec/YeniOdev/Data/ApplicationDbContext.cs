using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YeniOdev.Models;

namespace YeniOdev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Villa> Villa { get; set; }

        public DbSet<Bolge> Bolge { get; set; }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<User> User  { get; set; }

        public DbSet<Adres> Adres { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    }

