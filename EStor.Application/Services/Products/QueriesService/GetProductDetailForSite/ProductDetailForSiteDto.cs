namespace EStor.Application.Services.Products.QueriesService.GetProductDetailForSite;

public class ProductDetailForSiteDto
{
    public long Id { get; set; }
    public string Titel { get; set; }
    public string CategoryName { get; set; }
    public long CategoryId { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CountOfProductInInventory { get; set; }
    public int Star { get; set; }

    public List<ProductDetailFeatureForSiteDto> Featuers { get; set; }
    public List<string> Images { get; set; }
}