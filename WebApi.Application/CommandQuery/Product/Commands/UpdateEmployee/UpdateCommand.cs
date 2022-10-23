using MediatR;
using WebApi.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.CommandQuery.Products.Commands.UpdateProduct
{
	public record UpdateCommand
	(
	 string EmpCode,
	 string Status
	): IRequest<Message>;
}
