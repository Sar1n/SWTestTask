using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.IncentiveTypeStrategies
{
	public class FixedCashAmountStrategy : IIncentiveStrategy
	{
		public bool CanApply(Rebate rebate, Product product, CalculateRebateRequest request)
		{
			return rebate != null
				&& product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount)
				&& rebate.Amount > 0;
		}

		public decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebateRequest request)
		{
			return rebate.Amount;
		}
	}
}
