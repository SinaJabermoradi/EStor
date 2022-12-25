using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility;
using EStor.CommonUtility.DTO;
using Microsoft.EntityFrameworkCore;

namespace EStor.Application.Services.Products.QueriesService.GetProductForSite;

public class GetProductForSite : IGetProductForSite
{
    private readonly IDataBaseContext _context;
    public GetProductForSite(IDataBaseContext context)
    {
        _context = context;
    }

    public ServiceResultDto<ResultProductForSiteDto> Execute(Ordering orderParameter
        , string searchKey
        , int pageNumber
        , int pageSize
        , long? categoryId)
    {
        Random randomStar = new Random();
        int totalRow = 0;
        var productQuery = _context.Products
            .Include(product => product.Category)
            .Include(product => product.ProductImage).AsQueryable();

        if (categoryId != null)
            productQuery = productQuery
                .Where(product => product.Category.Id == categoryId
                                  || product.Category.ParentCategoryId == categoryId)
                .AsQueryable();

        if (!(string.IsNullOrWhiteSpace(searchKey)))
            productQuery = productQuery
                .Where(product => product.Name.Contains(searchKey)
                                  || product.Brand.Contains(searchKey)
                                  || product.Category.Name.Contains(searchKey))
                .AsQueryable();

        switch (orderParameter)
        {
            case Ordering.NotOrder:
                productQuery = productQuery
                    .OrderByDescending(product => product.Id)
                    .AsQueryable();
                break;

            case Ordering.MostVisited:
                productQuery = productQuery
                    .OrderByDescending(product => product.ViewCount)
                    .AsQueryable();
                break;

            case Ordering.MostSelling:
                //TODO ==> هر موقع سبد خرید رو نوشتم این رو تکمیل می کنم
                break;

            case Ordering.MostPopular: 
                // TODO ===> جمعی از اون محصولاتی که بیشترین بازدید رو داشتن و همچنین بیشترین خرید رو داشتن
                break;

            case Ordering.TheNewest:
                productQuery = productQuery
                    .OrderByDescending(product => product.Id)
                    .AsQueryable();
                break;

            case Ordering.Cheapest:
                productQuery = productQuery
                    .OrderBy(product => product.Price)
                    .AsQueryable();
                break;

            case Ordering.TheMostExpensive:
                productQuery = productQuery
                    .OrderByDescending(product => product.Price)
                    .AsQueryable();
                break;
        }


        var product = productQuery.ToPaged(pageNumber, pageSize, out totalRow);

        return new ServiceResultDto<ResultProductForSiteDto>
        {
            Data = new ResultProductForSiteDto
            {
                TotalRow = totalRow,
                Products = product.Select(product => new ProductForSiteDto
                {
                    Id = product.Id,
                    Star = randomStar.Next(1, 5),
                    Title = product.Name,
                    ImageSrc = product.ProductImage.FirstOrDefault().ImageSrc,
                    Price = product.Price
                }).ToList()
            },
            IsSuccess = true,
            Message = ""
        };
    }
}