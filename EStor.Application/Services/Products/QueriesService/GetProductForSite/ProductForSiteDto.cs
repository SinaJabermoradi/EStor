namespace EStor.Application.Services.Products.QueriesService.GetProductForSite;

public class ProductForSiteDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ImageSrc { get; set; }
    public int Star { get; set; }
    public decimal Price { get; set; }
}