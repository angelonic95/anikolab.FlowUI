using FlowUI.Common.Common;
using FlowUI.Strategy;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI
{
    public class GetAvailableActions : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            var recordId = context.InputParameters["recordId"] as string;
            var actionType = context.InputParameters["actionType"] as string;
            var entityName = context.InputParameters["entityName"] as string;
            var callerUserId = context.UserId.ToString();


            string response = string.Empty;

            IContext builderContext = new Context(callerUserId, entityName, recordId);

            AvailableActionStrategyFactory factory = new AvailableActionStrategyFactory(service, builderContext, tracingService);
            var config = factory.TryGetConfiguration(actionType);
            response = config;

            context.OutputParameters["Response"] = response;
        }
    }
}
