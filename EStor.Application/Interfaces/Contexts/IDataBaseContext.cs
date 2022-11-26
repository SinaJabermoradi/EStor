using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.Domain.Entities.Users;

namespace EStor.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }
    }
}
