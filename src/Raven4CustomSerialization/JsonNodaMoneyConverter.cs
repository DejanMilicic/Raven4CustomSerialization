using System;
using NodaMoney;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Raven4CustomSerialization
{
	public class JsonNodaMoneyConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			dynamic money = value;

			writer.WriteStartObject();
			writer.WritePropertyName("Amount");
			writer.WriteValue(money.Amount);
			writer.WritePropertyName("Currency");
			writer.WriteStartObject();
			writer.WritePropertyName("Code");
			writer.WriteValue(money.Currency.Code);
			writer.WriteEndObject();
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject money = JObject.Load(reader);
			string amount = money.Value<string>("Amount");
			string currencyCode = money["Currency"].Value<string>("Code");
			return Money.Parse(amount, Currency.FromCode(currencyCode));
		}

		public override bool CanConvert(Type objectType)
		{
			Console.WriteLine(objectType.ToString());
			return objectType == typeof(Money);
		}
	}
}
