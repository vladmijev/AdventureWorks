using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Contract.Response;
using Domain.Data;

namespace AdventureWorks.Services
{
	public interface IProductionService
	{
		ProductResponse GetProduct(string name, DateTime sellStartDate, string description);
	}
}
