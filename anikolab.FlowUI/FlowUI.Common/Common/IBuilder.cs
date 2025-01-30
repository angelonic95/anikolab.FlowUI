using System;
using System.Collections.Generic;
using System.Text;

namespace FlowUI.Common.Common
{
	public interface IBuilder<T>
	{
		T GetEntityConfiguration(string actionType);
		T BuildForm();
		T BuildSubgrid();
		T BuildRibbon();
	}
}
