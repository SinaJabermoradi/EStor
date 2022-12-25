using EStor.Domain.Entities.HomePage;

namespace EndPoint.MVCWebApplicationUI.Areas.AdminPanel.Models
{
    public class AddNewImageToHomePageViewModel
    {
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
