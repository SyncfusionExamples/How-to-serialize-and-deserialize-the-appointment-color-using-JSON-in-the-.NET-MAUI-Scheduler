using Newtonsoft.Json;

namespace SerializeAndDeserialize
{
    public class JsonColorConverter : JsonConverter<Brush>
    {
        public override Brush ReadJson(JsonReader reader, Type objectType, Brush? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.Value == null)
            {
                return Colors.Black;
            }
            string s = (string)reader.Value;
            return new SolidColorBrush(Color.FromArgb(s));
        }

        public override void WriteJson(JsonWriter writer, Brush? value, JsonSerializer serializer)
        {
            if(value == null)
            {
                return;
            }

            writer.WriteValue(((SolidColorBrush)value).Color.ToHex());
        }
    }
}