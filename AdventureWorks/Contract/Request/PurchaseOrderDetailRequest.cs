using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Contract.Request
{
	public class PurchaseOrderDetailRequest
	{

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

	}
}
