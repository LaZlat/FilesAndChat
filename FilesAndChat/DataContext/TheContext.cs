using FilesAndChat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndChat.DataContext
{
    public class TheContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FriendFile> FriendFiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=newdb");
        }

    }
}
