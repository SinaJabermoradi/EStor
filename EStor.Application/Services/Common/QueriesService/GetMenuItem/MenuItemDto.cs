namespace EStor.Application.Services.Common.QueriesService.GetMenuItem;

public class MenuItemDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public List<MenuItemDto> InnerMenu { get; set; }
}