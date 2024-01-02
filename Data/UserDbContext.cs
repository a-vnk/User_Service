using Microsoft.EntityFrameworkCore;
using Service_User.Model;
using System.Collections.Generic;


namespace Service_User.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
