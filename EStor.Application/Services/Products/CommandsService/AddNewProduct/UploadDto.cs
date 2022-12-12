namespace EStor.Application.Services.Products.CommandsService.AddNewProduct;

public class UploadDto
{
    public long Id { get; set; }
    public bool IsHaveStatus { get; set; }
    public string FileNameAddress { get; set; }
}