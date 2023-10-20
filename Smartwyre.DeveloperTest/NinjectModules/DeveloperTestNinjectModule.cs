using Ninject.Modules;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Services;

namespace Smartwyre.DeveloperTest.NinjectModules
{
	public class DeveloperTestNinjectModule : NinjectModule
	{

		public override void Load()
		{
			Bind<IRebateService>().To<RebateService>().InSingletonScope();

			Bind<IRebateDataStore>().To<RebateDataStore>().InSingletonScope();
			Bind<IProductDataStore>().To<ProductDataStore>().InSingletonScope();

			Bind<IIncentiveStrategyFactory>().To<IncentiveStrategyFactory>().InSingletonScope();
		}
	}
}
