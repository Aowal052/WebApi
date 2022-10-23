using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Interfaces;
using WebApi.Entity.Entities;
using WebApi.Infrastructure.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using WebApi.Application.CommandQuery.Products.Commands.UpdateProduct;
using WebApi.Application.CommandQuery.Product.Commands.DeleteProduct;

namespace WebApi.Infrastructure.Repositories
{
	public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
	{
		public ProductRepository(DataContext context) : base(context)
		{
		}

		public void DeleteProductAsync(DeleteProductCommand request)
		{
			try
			{
				var data = _context.Products.Where(x => x.ProductCode == request.Id).First();
				_context.Products.Remove(data);
				_context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IEnumerable<ProductEntity>> GetAllByTimeAsync(int userId, DateTime fromDate, DateTime toDate)
		{
			return await _context.Products.Where(x => x.Id == userId && (x.CreatedDate >= fromDate && x.CreatedDate <= toDate)).ToListAsync();
		}

		public async Task<IEnumerable<ProductEntity>> GetAllByUserAsync(int userId)
		{
			return await _context.Products.Where(x => x.Id == userId).ToListAsync();
		}

		public async Task<ProductEntity> UpdateAsync(UpdateCommand request)
		{
			var value =  _context.Products.First(x => x.ProductCode == request.EmpCode);
			value.Status = request.Status;
			await _context.SaveChangesAsync();
			return value;
		}
	}
}
