namespace EStor.Application.Services.Products.QueriesService.GetCategories;

public class CategoriesDto
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool CategoryHasChild { get; set; }
    public ParentCategoryDto CategoryParent { get; set; }

}