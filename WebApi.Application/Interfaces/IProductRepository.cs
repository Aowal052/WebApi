using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CommandQuery.Product.Commands.DeleteProduct;
using WebApi.Application.CommandQuery.Products.Commands.UpdateProduct;
using WebApi.Entity.Entities;

namespace WebApi.Application.Interfaces
{
    public interface IProductRepository : IAsyncRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllByTimeAsync(int userId, DateTime fromDate, DateTime toDate);
        Task<IEnumerable<ProductEntity>> GetAllByUserAsync(int userId);
        Task<ProductEntity> UpdateAsync(UpdateCommand request);
		void DeleteProductAsync(DeleteProductCommand request);
	}
}
