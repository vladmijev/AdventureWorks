using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Domain.Data;
using Microsoft.Extensions.DependencyInjection;
using Module = Autofac.Module;

namespace Domain
{
	public class DataModule: Module
	{
		private readonly IServiceCollection services;

		public DataModule(IServiceCollection services)
		{
			this.services = services;
		}

		protected override void Load(ContainerBuilder builder)
		{
			LoadDbContextsIntoServices();
			builder.RegisterType<AdventureWorks2016Context>().AsSelf().InstancePerLifetimeScope();
		}

		private void LoadDbContextsIntoServices()
		{
			services.AddDbContext<AdventureWorks2016Context>();
		}
	}
}
