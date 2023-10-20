using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
	private IRebateDataStore rebateDataStore;
	private IProductDataStore productDataStore;
	private IIncentiveStrategyFactory incentiveStrategyFactory;

	public RebateService(IRebateDataStore rebateDataStore,
		IProductDataStore productDataStore,
		IIncentiveStrategyFactory incentiveStrategyFactory)
	{
		this.rebateDataStore = rebateDataStore;
		this.productDataStore = productDataStore;
		this.incentiveStrategyFactory = incentiveStrategyFactory;
	}

	public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

		var strategy = incentiveStrategyFactory.GetStrategy(rebate.Incentive);

		var result = new CalculateRebateResult();

		if (strategy.CanApply(rebate, product, request))
		{
			result.Success = true;
			var rebateAmount = strategy.CalculateRebateAmount(rebate, product, request);
			rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
		}
		else
		{
			result.Success = false;
		}

        return result;
    }
}
