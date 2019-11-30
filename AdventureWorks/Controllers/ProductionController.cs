using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Produces("application/json")]
    public class ProductionController : ControllerBase
    {
		private readonly IProductionService _productionService;
		private readonly IPurchaseOrderDetailService _purchaseOrderDetailService;

		public ProductionController(IProductionService productionService, IPurchaseOrderDetailService purchaseOrderDetailService)
		{
			this._productionService = productionService;
			this._purchaseOrderDetailService = purchaseOrderDetailService;
		}

		[HttpGet("GetProduct")]
		public IActionResult GetProduct([FromQuery] string name, [FromQuery] string sellStartDate, [FromQuery] string description)
		{
			if (name == null || sellStartDate == null || description == null)
				return BadRequest();

			DateTime sellStartDateObj;
			if (!DateTime.TryParseExact(sellStartDate, "MM.dd.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sellStartDateObj))
				return BadRequest();

			return Ok(this._productionService.GetProduct(name, sellStartDateObj, description));
		}

		[HttpGet("GetPurchaseOrderDetail")]
		public IActionResult GetPurchaseOrderDetail([FromQuery] string startTime, [FromQuery] string endTime)
		{
			if (startTime == null || endTime == null)
				return BadRequest();


			DateTime startTimeObj;
			if (!DateTime.TryParseExact(startTime, "MM.dd.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTimeObj))
				return BadRequest();

			DateTime endTimeObj;
			if (!DateTime.TryParseExact(endTime, "MM.dd.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTimeObj))
				return BadRequest();

			return Ok(this._purchaseOrderDetailService.GetPurchaseOrderDetail(startTimeObj, endTimeObj));
		}
	}
}