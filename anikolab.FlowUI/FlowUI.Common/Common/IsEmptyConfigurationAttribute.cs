using System;
using System.Collections.Generic;
using System.Text;

namespace FlowUI.Common.Common
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public class IsEmptyConfigurationAttribute : Attribute
	{
	}
}
