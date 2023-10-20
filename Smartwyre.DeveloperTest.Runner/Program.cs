using System;
using Ninject;
using Smartwyre.DeveloperTest.NinjectModules;
using Ninject.Modules;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner
{
	class Program
	{
		static void Main(string[] args)
		{
			var kernel = new StandardKernel(new INinjectModule[] { new DeveloperTestNinjectModule() });

			var rebateService = kernel.Get<IRebateService>();

			var request = new CalculateRebateRequest()
			{
				RebateIdentifier = "RebateId",
				ProductIdentifier = "ProductId",
				Volume = 123m
			};

			var res = rebateService.Calculate(request);

			Console.WriteLine(res.ToString());
		}
	}

}