using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlowUI.Model.Ribbon
{
	[DataContract]
	public class AccountRibbonConfiguration
	{
		[DataMember]
		public bool showButton1 { get; set; }

		[DataMember(Name = "create", EmitDefaultValue = false)]
		public AccountRibbon create { get; set; }

		[DataMember(Name = "edit", EmitDefaultValue = false)]

		public AccountRibbon edit { get; set; }

		
	}



	[DataContract]
	public class AccountRibbon
	{
		
		[DataMember]
		public bool showButton2 { get; set; }

		[DataMember]
		public bool showButton3 { get; set; }

		[DataMember]
		public bool showButton4 { get; set; }
	}
}
