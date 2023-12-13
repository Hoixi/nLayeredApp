using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    IProductDal _productDal;
    public ProductBusinessRules(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task MaximumProductCategory(int CategoryId)
    {
        var result = await _productDal.GetListAsync(i => i.CategoryId == CategoryId);
        if (result.Count >= 20)
        {
            throw new BusinessException(BusinessMessages.ProductCategoryLimit);
        }
    }
}
