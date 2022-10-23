using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebApi.Application.CommandQuery.Products.Commands.CreateProducts;
using WebApi.Application.Helper;
using WebApi.Application.Interfaces;
using WebApi.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Application.CommandQuery.Products.Commands.UpdateProduct
{
	public class UpdateProductHandler : IRequestHandler<UpdateCommand, Message>
	{
		private readonly IMapper _iMapper;
		private readonly IProductRepository _iProductRepository;
		public UpdateProductHandler(IMapper iMapper, IProductRepository iProductRepository)
		{
			_iMapper = iMapper;
			_iProductRepository = iProductRepository;
		}

		public async Task<Message> Handle(UpdateCommand request, CancellationToken cancellationToken)
		{
			var register = await _iProductRepository.UpdateAsync(request);
			var message = new Message();
			//var Product = _iMapper.Map<Product>(emp);


			message = new Message()
			{
				StatusCode = Convert.ToInt32(HttpStatusCode.OK),
				StatusMessage = "Data Updated successfully"
			};

			return message;
		}
	}
}
