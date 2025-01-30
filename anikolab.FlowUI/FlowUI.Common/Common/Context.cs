using System;
using System.Collections.Generic;
using System.Text;

namespace FlowUI.Common.Common
{
	public sealed class Context : IContext
	{
		public bool IsNew { get => EntityId == Guid.Empty; }
		public Guid? CallerUserId { get => Guid.TryParse(_callerUserId, out Guid callerUserId) ? callerUserId : Guid.Empty; }
		public string EntityName { get => _entityName; }
		public Guid EntityId { get => Guid.TryParse(_entityId, out Guid entityId) ? entityId : Guid.Empty; }

		private string _entityName;
		private string _entityId;
		private string _callerUserId;

		public Context(string callerUserId, string entityName, string EntityId)
		{
			this._callerUserId = callerUserId;
			this._entityId = EntityId;
			this._entityName = entityName;
		}

	}
}
