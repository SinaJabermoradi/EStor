using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EStor.Domain.Entities.Carts;
using EStor.Domain.Entities.HomePage;
using EStor.Domain.Entities.Products;
using EStor.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ProductFeatures> ProductFeatures { get; set; }

        public DbSet<Slider> Slider { get; set; }

        public DbSet<HomePageImage> HomePageImages { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        
        public DbSet<CartItem> CartItems { get; set; }

        public int SaveChanges();

        public int SaveChanges(bool acceptAllChangesOnSuccess);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
              CancellationToken cancellationToken = new CancellationToken());
    }
}
