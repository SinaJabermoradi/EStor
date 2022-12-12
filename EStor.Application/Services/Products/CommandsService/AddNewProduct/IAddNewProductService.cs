using EStor.CommonUtility.DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace EStor.Application.Services.Products.CommandsService.AddNewProduct;

public interface IAddNewProductService
{
    public ServiceResultDto Execute(RequestAddNewProductDto request);
}