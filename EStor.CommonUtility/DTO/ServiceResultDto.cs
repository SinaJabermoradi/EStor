using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStor.CommonUtility.DTO
{
    /// <summary>
    /// این کلاس خروجی سرویس هاست.
    /// یعنی متد های کلاس های سرویس، در خروجی شون این کلاس رو ریترن می کنن.
    ///
    /// در این کلاس ، خروجی هایی که همه ی سرویس ها باید آن را بر گردانند وجود دارد
    /// </summary>
    public class ServiceResultDto
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }

    /// <summary>
    /// این کلاس خروجی همه ی سرویس هاست.
    /// یعنی متد های کلاس های سرویس، در خروجی شون این کلاس رو ریترن می کنن.
    ///
    /// در این کلاس ، خروجی هایی که همه ی سرویس ها باید آن را بر گردانند وجود دارد.
    ///
    /// اگر سرویس ما ، قصد داره دیتای دیگه ای هم بر گردونه از این کلاس استفاده می کنیم
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ServiceResultDto<TData>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }  // اگر سرویس شما ، غیر از دیتاهای عمومی ِهمه ی سرویس ها ، قصد دارد دیتای دیگری نیز ریترن کند از این پراپرتی استفاده کن
    }
}
