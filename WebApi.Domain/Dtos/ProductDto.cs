using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entity.Dtos
{
    public class ProductDto
    {
		public int Id { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string ProductPrice { get; set; }
		public string Status { get; set; }
	}
}
