using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entity.Entities
{
	public class Department:BaseEntity
	{
		public string Name { get; set; }
		public int CompanyId { get; set; }
	}
}
