using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Contract.Response;
using Domain.Data;

namespace AdventureWorks.Services
{
	public class PurchaseOrderDetailService : IPurchaseOrderDetailService
	{
		private readonly AdventureWorks2016Context context;
		
		public PurchaseOrderDetailService(AdventureWorks2016Context context)
		{
			this.context = context;
		}


		public PurchaseOrderDetailResponse GetPurchaseOrderDetail(DateTime startTime, DateTime endTime)
		{
			List<DateSumItem> lineTotals = this.context.PurchaseOrderDetail.GroupBy(x => x.ModifiedDate).Select(x => new DateSumItem { Date = x.Key, Sum = x.Sum(y => y.LineTotal) }).ToList();

			List<DateSumItem> productUnitsSold = this.context.PurchaseOrderDetail.GroupBy(x => x.ModifiedDate).Select(x => new DateSumItem { Date = x.Key, Sum = x.Sum(y => y.OrderQty) }).ToList();

			var lineTotalsSum = this.context.PurchaseOrderDetail.Where(x => x.ModifiedDate >= startTime && x.ModifiedDate <= endTime).Sum(y => y.LineTotal);

			var productUnitsSoldSum = this.context.PurchaseOrderDetail.Where(x => x.ModifiedDate >= startTime && x.ModifiedDate <= endTime).Sum(y => y.OrderQty);

			return new PurchaseOrderDetailResponse
			{
				LineTotals = lineTotals,
				ProductUnitsSold = productUnitsSold,
				LineTotalsSum = lineTotalsSum,
				ProductUnitsSoldSum = productUnitsSoldSum
			};
		}
	}

	
}
