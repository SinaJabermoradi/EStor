namespace EStor.Application.Services.Products.QueriesService.GetProductForAdmin;

public class GetProductForAdminDto
{
    public int RowCount { get; set; }   // تعداد کل سطر های جدول رو نمایش می ده . این کار برای پیج اینیشن هست 
    public int CurrentPage { get; set; }
    public int CountOfProductOnThePage { get; set; }
    public List<ProductInformationForAdminDto> ProductsForAdmin { get; set; }
}