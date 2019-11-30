using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Contract.Response;
using Domain.Data;

namespace AdventureWorks.Services
{
	public interface IPurchaseOrderDetailService
	{
		PurchaseOrderDetailResponse GetPurchaseOrderDetail(DateTime startTime, DateTime endTime);
	}
}
