using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;

namespace AdventureWorks.Contract.Response
{
	public class ProductResponse
	{
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<ProductDescription> Descriptions { get; set; }
	}
}
