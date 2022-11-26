using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStor.Domain.Entities.Users
{
    public class User
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// برای ایجاد رابطه ی چند به چند از این پراپرتی و کلاس (( یوزر این رول )) استفاده کردیم
        /// </summary>
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
