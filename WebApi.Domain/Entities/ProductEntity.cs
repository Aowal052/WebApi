using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entity.Entities
{
    public class ProductEntity : BaseEntity
    {
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string ProductPrice { get; set; }
        public string Status { get; set; }
    }
}
