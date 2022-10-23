using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity.Dtos;

namespace WebApi.Application.CommandQuery.Products.Queries.GetProducts
{
    public record GetProductListQuery() : IRequest<List<ProductDto>>;
}
