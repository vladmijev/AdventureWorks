using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Contract.Response
{
	public class PurchaseOrderDetailResponse
	{
		public IEnumerable<DateSumItem> LineTotals { get; set; }
		public IEnumerable<DateSumItem> ProductUnitsSold { get; set; }
		public decimal LineTotalsSum { get; set; }
		public decimal ProductUnitsSoldSum { get; set; }
	}
	public class DateSumItem
	{
		public DateTime Date { get; set; }
		public decimal Sum { get; set; }

	}
}
