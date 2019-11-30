using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AdventureWorks.IntegrationTests
{
	public abstract class IntegrationTest
	{

		protected readonly HttpClient httpClient;


		public IntegrationTest()
		{
			var factory = new WebApplicationFactory<Startup>();
			httpClient = factory.CreateClient();
		}


	}
}
