using FlowUI.Builder;
using FlowUI.Common.Common;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI.Strategy
{
	internal class AvailableActionStrategyFactory : IAvailableActionStrategy
	{
		private IContext context;
		private IOrganizationService service;
		private ITracingService tracingService;

		public AvailableActionStrategyFactory(IOrganizationService service, IContext context, ITracingService tracingService)
		{
			this.context = context;
			this.service = service;
			this.tracingService = tracingService;
		}

		public string TryGetConfiguration(string actionType)
		{
			switch (context.EntityName)
			{
				case "incident":
					return new IncidentBuilder(service, context, tracingService).GetEntityConfiguration(actionType).Build().AsJson();
				case "account":
					return new AccountBuilder(service, context, tracingService).GetEntityConfiguration(actionType).Build().AsJson();
				default:
					throw new NotImplementedException($"builder not found for entity :{context.EntityName}");
			}
		}

	}
}
