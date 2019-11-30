using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Data;
using AdventureWorks.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AdventureWorks.DependencyInjection;

namespace AdventureWorks
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public IContainer ApplicationContainer { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddOptions();

			services.AddSingleton<IProductionService, ProductionService>();
			services.AddSingleton<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
			services.AddSingleton<AdventureWorks2016Context>();

			services.AddMvc().AddControllersAsServices();

			services.AddDbContext<AdventureWorks2016Context>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")) );

			var builder = new ContainerBuilder();

			CompositionRoot compositionRoot = new CompositionRoot(services);
			compositionRoot.ComposeApplication(builder);

			builder.Populate(services);

			ApplicationContainer = builder.Build();

			return new AutofacServiceProvider(ApplicationContainer);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
