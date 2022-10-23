using MediatR;
using WebApi.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.CommandQuery.Product.Commands.DeleteProduct
{
	public record DeleteProductCommand
	(
	 string Id
	): IRequest<Message>;
}
