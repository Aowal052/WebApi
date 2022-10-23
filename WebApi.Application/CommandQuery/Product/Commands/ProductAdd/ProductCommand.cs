using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Helper;
using WebApi.Entity.Dtos;

namespace WebApi.Application.CommandQuery.Products.Commands.CreateProducts
{
    public record ProductCommand(
        string ProductName,
        string ProductPrice
        )
     : IRequest<Message>;
}
