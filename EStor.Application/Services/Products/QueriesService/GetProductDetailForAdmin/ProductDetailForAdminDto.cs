namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForAdmin;

public class ProductDetailForAdminDto
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CountOfProductInInventory { get; set; }
    public bool IsThisProductBeDisplayedOnTheSite { get; set; }

    public List<ProductDetailFeatureDto> Featuers { get; set; }
    public List<ProductDetailImageDto> Images { get; set; }
}