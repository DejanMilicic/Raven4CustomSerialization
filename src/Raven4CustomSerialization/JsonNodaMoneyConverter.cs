using Newtonsoft.Json;
using NodaMoney;
using System;

namespace Raven4CustomSerialization
{
	public class JsonNodaMoneyConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var money = (Money)value;

			writer.WriteStartObject();
			writer.WritePropertyName("Moneyz");
			serializer.Serialize(writer, money.Amount);
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Money);
		}
	}
}
