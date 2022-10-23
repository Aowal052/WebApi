using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Application.Interfaces;
using WebApi.Entity.Dtos;

namespace WebApi.Application.CommandQuery.Products.Queries.GetProducts
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IMapper _iMapper;
        private readonly IProductRepository _iProductRepository;

        public GetProductListQueryHandler(IMapper iMapper, IProductRepository iProductRepository)
        {
            _iMapper = iMapper;
            _iProductRepository = iProductRepository;
        }
        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var itemObj = await _iProductRepository.GetAllAsync();
            var items = itemObj.ToList();
            return _iMapper.Map<List<ProductDto>>(items);
        }
    }
}
