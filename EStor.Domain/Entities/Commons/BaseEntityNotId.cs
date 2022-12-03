using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStor.Domain.Entities.Commons
{
    public class BaseEntityNotId
    {
        /// <summary>
        ///  رکورد ، در چه زمانی به دیتابیس اضافه شده
        /// </summary>
        public DateTime InsertRecordTime { get; set; } = new DateTime();
        /// <summary>
        /// ( است Nullable )
        ///   رکورد ، در چه زمانی در دیتابیس ویرایش شده و تغییر کرده
        ///   
        /// </summary>
        public DateTime? UpdateRecordTime { get; set; }
        /// <summary>
        /// فلگی که مشخص می کنه دیتا از دیتابیس پاک شده یا نه
        /// </summary>
        public bool IsRemoved { get; set; } = false;
        /// <summary>
        ///   ( است Nullable )
        ///   رکورد ، در چه زمانی از دیتابیس حذف منطقی شده و فلگش ترو شده
        /// </summary>
        public DateTime? RemoveRecordTime { get; set; }
    }
}
