using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetProductForAdmin;

public class GetProductForAdminService:IGetProductForAdminService
{
    private readonly IDataBaseContext _context;
    public GetProductForAdminService(IDataBaseContext context)
    {
        _context = context;
    }
        
    public ServiceResultDto<GetProductForAdminDto> Execute(int pageNumber
        , int countOfProductOnThePage)
    {
        int rowCount = 0;

        var products = _context.Products.Include(product=>product.Category)
            .ToPaged(pageNumber, countOfProductOnThePage,out rowCount)
            .Select(product => new ProductInformationForAdminDto
            {
                Id=product.Id,
                Name = product.Name,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Description = product.Description,
                Price = product.Price,
                CountOfProductInInventory = product.CountOfProductInInventory,
                IsThisProductBeDisplayedOnTheSite = product.IsThisProductBeDisplayedOnTheSite
            }).ToList();

        return new ServiceResultDto<GetProductForAdminDto>
        {
            IsSuccess = true,
            Message = "",
            Data = new GetProductForAdminDto
            {
                RowCount = rowCount,
                CurrentPage = pageNumber,
                CountOfProductOnThePage = countOfProductOnThePage,
                ProductsForAdmin = products
            }
        };
    }


}