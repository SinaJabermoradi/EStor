using EStor.Application.Interfaces.Contexts;
using EStor.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EStor.Persistence.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet تبدیل کردن کلاس های مدلمون یا انتیتی مون به جداول دیتابیس به کمک 
        
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole 
                { Id = 1, Name = EStor.CommonUtility.Roles.Roles.Admin });
           
            modelBuilder.Entity<UserRole>().HasData(new UserRole
                { Id = 2, Name = EStor.CommonUtility.Roles.Roles.Operator });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
                {
                    Id = 3 , Name =  EStor.CommonUtility.Roles.Roles.Customer});
        }
    }
}
