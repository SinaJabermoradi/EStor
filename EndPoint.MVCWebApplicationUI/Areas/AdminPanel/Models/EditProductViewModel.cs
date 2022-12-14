using EStor.Application.Services.Products.CommandsService.AddNewProduct;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Models
{
    public class EditProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long CountOfProductInInventory { get; set; }
        public bool IsThisProductBeDisplayedOnTheSite { get; set; }
        public long CategoryId { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }
    }
}
