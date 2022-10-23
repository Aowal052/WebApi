using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApi.Application.CommandQuery.Accounts.Queries.Login;
using WebApi.Application.CommandQuery.Products.Commands.CreateProducts;
using WebApi.Application.CommandQuery.Products.Queries.GetProducts;
using WebApi.Application.CommandQuery.Products.Commands.UpdateProduct;
using WebApi.Application.CommandQuery.Product.Commands.DeleteProduct;
using WebApi.Application.CommandQuery.Product.Queries.GetProductById;

namespace WebApiApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator _iMediator;

        public ProductController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpPost("create-Product")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAsync(ProductCommand command) => Ok(await _iMediator.Send(command));

        [HttpGet("getall")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllAsync() => Ok(await _iMediator.Send(new GetProductListQuery()));
        
        [HttpPost("getById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetByIdAsync(GetProductByIdCommand command) => Ok(await _iMediator.Send(command));

        
        [HttpPost("update-status")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateStatusAsync(UpdateCommand entity) => Ok(await _iMediator.Send(entity));

        [HttpPost("delete-Product")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteProductAsync(DeleteProductCommand entity) => Ok(await _iMediator.Send(entity));
    }
}
