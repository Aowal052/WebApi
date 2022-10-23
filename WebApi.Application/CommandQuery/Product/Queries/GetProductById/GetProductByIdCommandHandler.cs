using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Application.Helper;
using WebApi.Application.Interfaces;
using WebApi.Entity.Dtos;

namespace WebApi.Application.CommandQuery.Product.Queries.GetProductById
{
	public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, ProductDto>
	{
		private readonly IMapper _iMapper;
		private readonly IProductRepository _iProductRepository;
		public GetProductByIdCommandHandler(
			IMapper mapper,
			IProductRepository productRepository
			)
		{
			_iMapper = mapper;
			_iProductRepository = productRepository;
		}
		public async Task<ProductDto> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var product = await _iProductRepository.GetByIdAsync(request.Id);
				return _iMapper.Map<ProductDto>(product);
			}
			catch (Exception ex)
			{
				throw;			}
		}
	}
}
