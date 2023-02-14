using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EliteOpenLibrary.Classes
{
    public class EliteXmlSerializer : XmlSerializer
    {

        public EliteXmlSerializer(Type type) : base(type) { }

        public new void Serialize(TextWriter textWriter, object o)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            Serialize(textWriter, o, ns);
        }

        public new void Serialize(XmlWriter xmlWriter, object o)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            Serialize(xmlWriter, o, ns);
        }

        public new void Serialize(Stream stream, object o)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            Serialize(stream, o, ns);
        }
    }
}
