using EStor.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EStor.Persistence.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet تبدیل کردن کلاس های مدلمون یا انتیتی مون به جداول دیتابیس به کمک 
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        #endregion

    }
}
