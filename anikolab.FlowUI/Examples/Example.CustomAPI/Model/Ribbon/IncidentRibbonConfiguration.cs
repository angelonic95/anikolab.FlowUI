using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI.Model.Ribbon
{
	[DataContract]
	public class IncidentRibbonConfiguration
	{
		[DataMember]
		public bool showButton1 { get; set; }
		[DataMember]
		public bool showGetInfoFlyOut { get; set; }
		[DataMember]
		public bool showGetId { get; set; }
		[DataMember]
		public bool showGetName { get; set; }
		[DataMember]
		public bool showGetEntityName { get; set; }

		public IncidentRibbonConfiguration()
		{

		}
	}
}
