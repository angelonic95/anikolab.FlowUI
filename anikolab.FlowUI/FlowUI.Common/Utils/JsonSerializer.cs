using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FlowUI.Common.Utils
{
	public static class JsonSerializer
	{
		public static string Serialize<T>(T t, params Type[] knownTypes)
		{
			var ser = new DataContractJsonSerializer(typeof(T), knownTypes);

			var ms = new MemoryStream();

			ser.WriteObject(ms, t);

			var jsonString = Encoding.UTF8.GetString(ms.ToArray());

			ms.Close();

			return jsonString;
		}

		
		public static T Deserialize<T>(string jsonString, params Type[] knownTypes)
		{
			var ser = new DataContractJsonSerializer(typeof(T), knownTypes);

			var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString))
			{
				Position = 0
			};
			var obj = (T)ser.ReadObject(ms);

			ms.Close();

			return obj;
		}

		
	}
}
