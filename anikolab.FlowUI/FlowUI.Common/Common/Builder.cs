using System;
using System.Collections.Generic;
using System.Text;

namespace FlowUI.Common.Common
{
	public abstract class Builder<T> : IBuilder<T> where T : class
	{
		public abstract T BuildForm();

		public abstract T BuildRibbon();

		public abstract T BuildSubgrid();

		public T GetEntityConfiguration(string actionType)
		{
			switch (actionType.ToLower())
			{
				case "form":
					return BuildForm();
				case "subgrid":
					return BuildSubgrid();
				case "ribbon":
					return BuildRibbon();
				default:
					throw new NotImplementedException($"Action type <{actionType}> not implemented");
			}
		}

		

		
	}
}
