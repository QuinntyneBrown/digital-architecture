using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static System.String;

namespace DigitalArchitecture.Dtos
{
    public class PropertyDto
    {
        public PropertyDto(DigitalArchitecture.Models.Property entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Key = entity.Key;
            Value = entity.Value;
            BaseUri = entity.BaseUri;
            Uri = entity.Uri;
            HtmlBody = entity.HtmlBody;
            PropertyType = entity.PropertyType;
        }

        public PropertyDto()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string BaseUri { get; set; }
        public string Uri { get; set; }
        public bool IsDynamic { get { return !IsNullOrEmpty(Uri); } }
        public string HtmlBody { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Models.PropertyType PropertyType { get; set; } = Models.PropertyType.Dynamic;
    }
}
