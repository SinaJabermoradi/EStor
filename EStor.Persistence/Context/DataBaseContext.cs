using EStor.Application.Interfaces.Contexts;
using EStor.Domain.Entities.HomePage;
using EStor.Domain.Entities.Products;
using EStor.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EStor.Persistence.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSet تبدیل کردن کلاس های انتیتی مون به جداول دیتابیس به کمک 
        
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ProductFeatures> ProductFeatures{ get; set; }

        public DbSet<Slider> Slider { get; set; }
        
        public DbSet<HomePageImage> HomePageImages { get; set; }

        #endregion


        #region Saves Data Codes

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

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess
                                , CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region افزودن ِمقادیر پیشفرض ِنقش ها در دیتابیس

            SeedData(modelBuilder);

            #endregion

            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique(); // برای اینکه در بیزینس یا منطق برنامه ی ما ===> ایمیل کاربر خیلی مهمه و در واقع تعیین کننده ی هویت ِکاربر هست ===> ما از ایندکس استفاده کردیم تا مطمئن بشیم که ایمیل کاربران کاملا منحصر به فرد و غیر تکراری است ====> یعنی به کمک ِ این قطعه کد ، کاری کردیم که ایمیل های تکراری نتونن وارد برنامه بشن   

            // برای افزودن محدودیت هایی بر روی کویری هاست
            ApplyQueryFilter(modelBuilder);

        }

        private static void ApplyQueryFilter(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasQueryFilter(user =>
                    !user.IsRemoved); // به کمک این قطعه کد مشخص می کنیم که انتیتی یوزر ، فقط اون یوزر ها یا کاربرانی رو برای من لود کن که (( ایز ریموو )) نباشن

            modelBuilder.Entity<Role>()
                .HasQueryFilter(role =>
                    !role.IsRemoved); // این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<UserRole>()
                .HasQueryFilter(userRole =>
                    !userRole.IsRemoved); // این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<Category>()
                .HasQueryFilter(category =>
                    !category.IsRemoved); // این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<Product>()
                .HasQueryFilter(product => 
                    !product.IsRemoved);// این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<ProductImage>()
                .HasQueryFilter(image =>
                    !image.IsRemoved);// این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<Slider>()
                .HasQueryFilter(slider =>
                    !slider.IsRemoved);// این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده

            modelBuilder.Entity<HomePageImage>()
                .HasQueryFilter(image =>
                    !image.IsRemoved); // این داره میگه اگر پاک نشده بود ، دیتا رو نشون بده و اگر پاک شده بود دیگه نشون نده
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
                { Id = 1, Name = EStor.CommonUtility.Roles.Roles.Admin });

            modelBuilder.Entity<Role>().HasData(new Role
                { Id = 2, Name = EStor.CommonUtility.Roles.Roles.Operator });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = EStor.CommonUtility.Roles.Roles.Customer
            });
        }
    }
}
