using Smartwyre.DeveloperTest.IncentiveTypes;
using Smartwyre.DeveloperTest.IncentiveTypeStrategies;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Factories
{
	public class IncentiveStrategyFactory : IIncentiveStrategyFactory
	{
		public IIncentiveStrategy GetStrategy(IncentiveType incentiveType)
		{
			switch (incentiveType)
			{
				case IncentiveType.FixedCashAmount:
					return new FixedCashAmountStrategy();
				case IncentiveType.FixedRateRebate:
					return new FixedRateRebateStrategy();
				case IncentiveType.AmountPerUom:
					return new AmountPerUomStrategy();

				default:
					throw new NotImplementedException($"{incentiveType} not supported");
			}
		}
	}
}
