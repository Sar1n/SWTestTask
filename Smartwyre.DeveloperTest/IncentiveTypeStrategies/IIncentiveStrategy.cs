using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.IncentiveTypeStrategies
{
	public interface IIncentiveStrategy
	{
		bool CanApply(Rebate rebate, Product product, CalculateRebateRequest request);

		decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebateRequest request);
	}
}
