using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStor.CommonUtility.DTO
{
    /// <summary>
    /// این کلاس ، موارد یا دیتاهایی که یک سرویس نیاز دارد تا به عنوان خروجی به ما برگرداند و به ما نشان دهد را در خودش نگاه می دارد
    /// این کلاس برای اینکه به عنوان ِخروجی ِسرویس مون ازش استفاده کنیم عالی است
    /// </summary>
    public class ServiceResultDto
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }

    /// <summary>
     /// این کلاس ، موارد یا دیتاهایی که یک سرویس نیاز دارد تا به عنوان خروجی به ما برگرداند و به ما نشان دهد را در خودش نگاه می دارد
    /// این کلاس برای اینکه به عنوان ِخروجی ِسرویس مون ازش استفاده کنیم عالی است
    /// اما گاهی پیش میاد که می خوایم علاوه بر این موارد ، سرویس مون دیتا های دیگه ای نیز برای ما بر گرداند
    /// کافیه در ورودی جنریک این کلاس ، بگیم که خروجی دیگر ِسرویس ِما از چه جنسی می خواهد باشد.
    /// بعد می توانیم دیتاهای دیگری نیز به عنوان خروجی سرویس مون بر گردانیم
    /// </summary>
    /// <typeparam name="TOtherServiceResult"></typeparam>
    public class ServiceResultDto<TOtherServiceResult>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public TOtherServiceResult OtherServiceResultData { get; set; }
    }
}
