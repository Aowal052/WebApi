using AutoMapper;
using MediatR;
using WebApi.Application.CommandQuery.Products.Commands.UpdateProduct;
using WebApi.Application.Helper;
using WebApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Application.CommandQuery.Product.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Message>
	{
		private readonly IMapper _iMapper;
		private readonly IProductRepository _iProductRepository;
		public DeleteProductCommandHandler(IMapper iMapper, IProductRepository iProductRepository)
		{
			_iMapper = iMapper;
			_iProductRepository = iProductRepository;
		}
		public async Task<Message> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			try
			{
				 _iProductRepository.DeleteProductAsync(request);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			//var Product = _iMapper.Map<Product>(emp);


			var message = new Message()
			{
				StatusCode = Convert.ToInt32(HttpStatusCode.OK),
				StatusMessage = "Data Deleted successfully"
			};

			return message;
		}
	}
}
