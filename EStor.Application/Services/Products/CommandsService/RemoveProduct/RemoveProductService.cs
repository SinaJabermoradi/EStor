using EStor.Application.Interfaces.Contexts;
using EStor.CommonUtility.DTO;

namespace EStor.Application.Services.Products.CommandsService.RemoveProduct;

public class RemoveProductService : IRemoveProductService
{
    private readonly IDataBaseContext _context;
    public RemoveProductService(IDataBaseContext context)
    {
        _context = context;
    }


    public ServiceResultDto Execute(long productId)
    {
        var product = _context.Products.Find(productId);
        if (product == null)
        {
            return new ServiceResultDto
            {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }

        product.RemoveRecordTime = DateTime.Now;
        product.IsRemoved = true;
        _context.SaveChanges();
        return new ServiceResultDto
        {
            IsSuccess = true,
            Message = "محصول با موفقیت از سایت حذف شد"
        };
    }
}