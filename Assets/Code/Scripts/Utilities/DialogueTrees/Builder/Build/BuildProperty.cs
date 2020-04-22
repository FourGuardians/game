using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Property BuildProperty(XmlElement element) => new Property()
        {
            Name = element.GetAttribute("name")
        };
    }
}