using Smartwyre.DeveloperTest.IncentiveTypeStrategies;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Factories
{
	public interface IIncentiveStrategyFactory
	{
		public IIncentiveStrategy GetStrategy(IncentiveType incentiveType);
	}
}
