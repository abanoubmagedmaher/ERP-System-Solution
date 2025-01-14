﻿using AutoMapper;
using Core.Entities;
using ERP_System.DTOS;

namespace ERP_System.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductURLResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
