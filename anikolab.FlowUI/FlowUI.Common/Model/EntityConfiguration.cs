using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using FlowUI.Common.Common;
using FlowUI.Common.Utils;

namespace FlowUI.Common.Model
{
	[DataContract]
	public class EntityConfiguration<TForm, TRibbon, TSubgrid> where TForm : class where TRibbon : class where TSubgrid : class
	{
		[DataMember(Name = "form", EmitDefaultValue = false)]
		public TForm Form { get; set; }
		[DataMember(Name = "ribbon", EmitDefaultValue = false)]
		public TRibbon Ribbon { get; set; }
		[DataMember(Name = "subgrid", EmitDefaultValue = false)]
		public TSubgrid Subgrid { get; set; }


		public EntityConfiguration(TForm form, TRibbon ribbon, TSubgrid subgrid)
		{
			Form = form;
			Ribbon = ribbon;
			Subgrid = subgrid;
		}

		public string ToJson()
		{
			if (Form != null && Form.GetType().IsDefined(typeof(IsEmptyConfigurationAttribute), true))
			{
				Form = null;
			}

			if (Ribbon != null && Ribbon.GetType().IsDefined(typeof(IsEmptyConfigurationAttribute), true))
			{
				Ribbon = null;
			}

			if (Subgrid != null && Subgrid.GetType().IsDefined(typeof(IsEmptyConfigurationAttribute), true))
			{
				Subgrid = null;
			}
			return JsonSerializer.Serialize(this, this.GetType());
		}
	}
}
