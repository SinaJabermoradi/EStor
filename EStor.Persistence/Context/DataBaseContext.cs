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


        #region ذخیره کردن دیتا

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

    }
}
