using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.Products.CommandsService.AddNewProduct;

public class RequestAddNewProductDto  // یک محصول چه خصوصیاتی می تواند داشته باشد. هر چی خصوصیت دارد را اینجا می نویسیم
{
    public string Name { get; set; }  // نام محصول
    public string Brand { get; set; }  // برند محصول
    public string Description { get; set; }  // توضیحات محصول
    public decimal Price { get; set; }  // قیمت محصول
    public long CountOfProductInInventory { get; set; }  // تعداد موجودی محصول در انبار
    public bool IsThisProductBeDisplayedOnTheSite { get; set; }  // آیا این محصول در سایت نمایش داده شود



    public long CategoryId { get; set; }  // ایدی اون دسته بندی ای که قبلا در سیستم اضافه کردیم رو می گیره تا بتونیم این محصول رو در اون دسته بندی اضافه کنیم



    public List<IFormFile> Image { get; set; }
    public List<AddNewProduct_Features> Features { get; set; }
}