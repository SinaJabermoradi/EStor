using EStor.Application.Services.Products.CommandsService.AddNewProduct;
using Microsoft.AspNetCore.Http;

namespace EStor.Application.Services.Products.CommandsService.EditProduct;

public class RequestProductForEditDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CountOfProductInInventory { get; set; }
    public bool IsThisProductBeDisplayedOnTheSite { get; set; }


    public List<IFormFile> Images { get; set; }
    public List<AddNewProduct_Features> Features { get; set; }
}