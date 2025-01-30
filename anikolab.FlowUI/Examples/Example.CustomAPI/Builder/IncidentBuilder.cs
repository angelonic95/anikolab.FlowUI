using FlowUI.Common.Builder;
using FlowUI.Common.Common;
using FlowUI.Common.Model;
using FlowUI.Model.Ribbon;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI.Builder
{
	public class IncidentBuilder : BuilderBase<IncidentBuilder, NullableObject, IncidentRibbonConfiguration, NullableObject>
	{

		private IOrganizationService service;
		private IContext context;
		private ITracingService tracingService;

		public IncidentBuilder(IOrganizationService service, IContext context, ITracingService tracingService)
		{
			this.service = service;
			this.context = context;
			this.tracingService = tracingService;
		}

		public override IncidentBuilder BuildForm()
		{
			return this;
		}

		public override IncidentBuilder BuildRibbon()
		{
			IsVisible(this.ribbonConfiguration, nameof(IncidentRibbonConfiguration.showButton1), true)
			.SetGetInfoFlyOut(!context.IsNew);
			return this;
		}

		public override IncidentBuilder BuildSubgrid()
		{
			return this;
		}
		private IncidentBuilder SetGetInfoFlyOut(bool show)
		{

			IsVisible(this.ribbonConfiguration, nameof(IncidentRibbonConfiguration.showGetInfoFlyOut), show)
			.IsVisible(this.ribbonConfiguration, nameof(IncidentRibbonConfiguration.showGetId), show)
			.IsVisible(this.ribbonConfiguration, nameof(IncidentRibbonConfiguration.showGetName), show)
			.IsVisible(this.ribbonConfiguration, nameof(IncidentRibbonConfiguration.showGetEntityName), show);

			return this;
		}
	}
}
