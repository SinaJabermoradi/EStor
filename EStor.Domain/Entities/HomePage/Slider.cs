using System.Numerics;
using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.HomePage;

public class Slider : BaseEntity
{
    public string ImageSrc { get; set; }
    public string Link { get; set; }  // اگر روی عکس کلیک شد به کجا بره
    public long ClickCount { get; set; }  // تعداد دفعاتی که کاربران روی این عکس کلیک کردن ===> کلیک خورش چقدره
}