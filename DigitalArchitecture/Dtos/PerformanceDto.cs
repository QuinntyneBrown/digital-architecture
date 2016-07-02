using DigitalArchitecture.Models;
using System.Xml;
using static Newtonsoft.Json.JsonConvert;

namespace DigitalArchitecture.Dtos
{
    public class PerformanceDto
    {
        public PerformanceDto()
        {

        }

        public PerformanceDto(Performance entity)
        {
            var doc = new XmlDocument();
            doc.LoadXml(entity.Properties);
            Properties = SerializeXmlNode(doc);
        }

        public string Properties { get; set; }
    }
}
