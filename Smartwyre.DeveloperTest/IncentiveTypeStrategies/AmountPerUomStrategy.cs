using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.IncentiveTypeStrategies
{
	public class AmountPerUomStrategy : IIncentiveStrategy
	{
		public bool CanApply(Rebate rebate, Product product, CalculateRebateRequest request)
		{
			return rebate != null
				&& product != null
				&& product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom)
				&& rebate.Amount > 0
				&& request.Volume > 0;
		}

		public decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebateRequest request)
		{
			return rebate.Amount * request.Volume;
		}
	}
}
