using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Users
{
    public class User :BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false; // برای غیر فعال کردن یا فعال کردن برنامه مون به کار میره
        /*
        /// برای ایجاد رابطه ی چند به چند از این پراپرتی و کلاس (( یوزر این رول )) استفاده کردیم
       */
        public ICollection<UserRole> UsersRoles { get; set; }
    }
}
