using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Contract.Response;
using Domain.Data;

namespace AdventureWorks.Services
{
	public class ProductionService : IProductionService
	{
		private readonly AdventureWorks2016Context context;
		
		public ProductionService(AdventureWorks2016Context context)
		{
			this.context = context;
		}


		public ProductResponse GetProduct(string name, DateTime sellStartDate, string description)
		{
			var products = this.context.Product.Where(x => x.Name == name && x.SellStartDate == sellStartDate).ToList();

			var descriptions = this.context.ProductDescription.Where(x => x.Description.Contains(description)).ToList();

			return new ProductResponse {Products = products, Descriptions = descriptions };
		}
	}
}
