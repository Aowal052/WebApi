using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Application.Helper;
using WebApi.Application.Interfaces;
using WebApi.Entity.Entities;

namespace WebApi.Application.CommandQuery.Products.Commands.CreateProducts
{
    public class ProductCommandHandler : IRequestHandler<ProductCommand, Message>
    {
        private readonly IMapper _iMapper;
        private readonly IProductRepository _iProductRepository;
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public ProductCommandHandler(IMapper iMapper, IProductRepository iProductRepository, IHttpContextAccessor iHttpContextAccessor)
        {
            _iMapper = iMapper;
            _iProductRepository = iProductRepository;
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public async Task<Message> Handle(ProductCommand request, CancellationToken cancellationToken)
        {

            var currentUser = _iHttpContextAccessor.HttpContext.User;
            var userId = currentUser.Claims.Where(c => c.Type == "Id").Select(x => x.Value).FirstOrDefault();
            var prod = _iMapper.Map<ProductEntity>(request);
            var message = new Message();
            prod.CreatedDate = DateTime.Now;
            prod.CreatedBy = Convert.ToInt32(userId);
            try
            {
                var responce = await _iProductRepository.AddAsync(prod);
                if (responce.Id > 0)
                {
                    message = new Message()
                    {
                        Id = responce.Id,
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        StatusMessage = "Data saved successfully"
                    };
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
