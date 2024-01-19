using Newtonsoft.Json;

namespace SerializeAndDeserialize
{
    public class JsonColorConverter : JsonConverter<Brush>
    {
        public override Brush ReadJson(JsonReader reader, Type objectType, Brush existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return new SolidColorBrush(Color.FromArgb(s));
        }

        public override void WriteJson(JsonWriter writer, Brush value, JsonSerializer serializer)
        {
            writer.WriteValue(((SolidColorBrush)value).Color.ToHex());
        }
    }
}