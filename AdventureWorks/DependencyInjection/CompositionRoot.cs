using Autofac;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.DependencyInjection
{
	public class CompositionRoot
	{
		private readonly IServiceCollection services;

		public CompositionRoot(IServiceCollection services)
		{
			this.services = services;
		}

		public virtual void ComposeApplication(ContainerBuilder builder)
		{
			builder.RegisterModule(new DataModule(services));
		}
	}
}
