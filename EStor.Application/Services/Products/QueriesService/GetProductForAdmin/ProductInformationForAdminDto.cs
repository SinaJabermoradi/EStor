using EStor.Domain.Entities.Products;

namespace EStor.Application.Services.Products.QueriesService.GetProductForAdmin;

public class ProductInformationForAdminDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CountOfProductInInventory { get; set; }
    public bool IsThisProductBeDisplayedOnTheSite { get; set; }
}