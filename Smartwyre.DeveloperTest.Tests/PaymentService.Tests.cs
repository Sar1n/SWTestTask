using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
	private string RebateIdentifier = "1";
	private string ProductIdentifier = "1";

	private IRebateService rebateService;
	private IncentiveStrategyFactory incentiveStrategyFactory;

	private Mock<IRebateDataStore> rebateDataStore;
	private Mock<IProductDataStore> productDataStore;

	public PaymentServiceTests()
	{
		rebateDataStore = new Mock<IRebateDataStore>(MockBehavior.Strict);

		productDataStore = new Mock<IProductDataStore>(MockBehavior.Strict);

		incentiveStrategyFactory = new IncentiveStrategyFactory();

		rebateService = new RebateService(rebateDataStore.Object, productDataStore.Object, incentiveStrategyFactory);
	}

	[Theory]
	[InlineData(50, true)]
	[InlineData(0, false)]
	public void RebateServiceTest(decimal price, bool success)
	{
		decimal percentage = 50m;
		decimal volume = 123m;

		SetupRebateGetMock(percentage);
		SetupProductGetMock(price);
		if (success)
		{
			SetupRebateStoreMock(price * percentage * volume);
		}

		var request = new CalculateRebateRequest()
		{
			RebateIdentifier = RebateIdentifier,
			ProductIdentifier = ProductIdentifier,
			Volume = volume
		};

		var result = rebateService.Calculate(request);

		Assert.Equal(success, result.Success);
	}

	internal void SetupRebateGetMock(decimal percentage) => rebateDataStore
		.Setup(x => x.GetRebate(RebateIdentifier))
		.Returns(new Rebate()
		{
			Identifier = "RebateIdentifier",
			Incentive = IncentiveType.FixedRateRebate,
			Amount = 100,
			Percentage = percentage
		});

	internal void SetupRebateStoreMock(decimal rebateAmount) => rebateDataStore
		.Setup(x => x.StoreCalculationResult(It.IsAny<Rebate>(), rebateAmount));

	internal void SetupProductGetMock(decimal productPrice) => productDataStore
		.Setup(x => x.GetProduct(ProductIdentifier))
		.Returns(new Product()
		{
			Id = 1,
			Identifier = ProductIdentifier,
			Price = productPrice,
			Uom = "1",
			SupportedIncentives = SupportedIncentiveType.FixedRateRebate
		});
}
