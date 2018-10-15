using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Security.Claims;
using System;

namespace HackerNewsOpinionatedTopApi.Models
{
    public class HnContext: DbContext
    {
        public HnContext(DbContextOptions<HnContext> options)
            : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
