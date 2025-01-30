using FlowUI.Common.Builder;
using FlowUI.Common.Common;
using FlowUI.Common.Model;
using FlowUI.Model.Ribbon;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI.Builder
{
	public class AccountBuilder : BuilderBase<AccountBuilder, NullableObject, AccountRibbonConfiguration, NullableObject>
	{
		private IOrganizationService service;
		private IContext context;
		private ITracingService tracingService;

		public AccountBuilder(IOrganizationService service, IContext context, ITracingService tracingService)
		{
			this.service = service;
			this.context = context;
			this.tracingService = tracingService;
		}


		public override AccountBuilder BuildForm()
		{
			throw new NotImplementedException();
		}

		public override AccountBuilder BuildRibbon()
		{
			var createRibbon = this.ribbonConfiguration.create;
			var editRibbon = this.ribbonConfiguration.edit;

			IsVisible(this.ribbonConfiguration, nameof(AccountRibbonConfiguration.showButton1), true);
			IsVisible(ref createRibbon, nameof(AccountRibbon.showButton2), false);
			IsVisible(ref editRibbon, nameof(AccountRibbon.showButton2), true);

			this.ribbonConfiguration.create = createRibbon;
			this.ribbonConfiguration.edit = editRibbon;

			return this;
		}

		public override AccountBuilder BuildSubgrid()
		{
			throw new NotImplementedException();
		}
	}
}
