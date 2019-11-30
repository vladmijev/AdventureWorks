using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Contract.Request
{
	public class ProductRequest
	{

		public string Name { get; set; }
		public DateTime SellStartDate { get; set; }
		public string Description { get; set; }

	}
}
