﻿using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    IMapper _mapper;


    public ProductManager(IProductDal productDal , IMapper mapper)
    {
        _productDal = productDal;      
        _mapper = mapper;
    }

    public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
    {
        Product product = _mapper.Map<Product>(createProductRequest);
        Product createdProduct = await _productDal.AddAsync(product);
        CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
        return createdProductResponse;
    }

    public async Task<GetListResponse> GetListAsync()
    {
        IPaginate<Product> products = await _productDal.GetListAsync();
        GetListResponse mapped = _mapper.Map<GetListResponse>(products);
        return mapped;
    }
}
