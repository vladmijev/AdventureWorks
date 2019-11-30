using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventureWorks.IntegrationTests
{
	[TestClass]
	public class ProductionControllerTest : IntegrationTest
	{
		[TestMethod]
		public async Task GetProduct_WithData_ReturnsOkRequest()
		{

			string requestUri = "http://localhost:1357/api/Production/GetProduct?name=test1&description=test2&sellStartDate=01.01.2019";

			var response = await httpClient.GetAsync(requestUri);
			
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[TestMethod]
		public async Task GetProduct_WithoutData_ReturnsBadRequest()
		{

			string requestUri = "http://localhost:1357/api/Production/GetProduct";

			var response = await httpClient.GetAsync(requestUri);

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[TestMethod]
		public async Task GetPurchaseOrderDetail_WithoutData_ReturnsBadRequest()
		{

			string requestUri = "http://localhost:1357/api/Production/GetPurchaseOrderDetail";

			var response = await httpClient.GetAsync(requestUri);

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[TestMethod]
		public async Task GetPurchaseOrderDetail_WithData_ReturnsOkRequest()
		{

			string requestUri = "http://localhost:1357/api/Production/GetPurchaseOrderDetail?startTime=01.11.2019&endTime=01.11.2019";

			var response = await httpClient.GetAsync(requestUri);

			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}
	}
}
