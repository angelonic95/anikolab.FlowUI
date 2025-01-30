using System;
using System.Collections.Generic;
using System.Text;

namespace FlowUI.Common.Common
{
	public interface IContext
	{
		bool IsNew { get; }
		Guid? CallerUserId { get; }
		string EntityName { get; }
		Guid EntityId { get; }

	}
}
