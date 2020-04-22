using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Modifier BuildModifier(XmlElement element) => new Modifier()
        {
            Name = element.GetAttribute("name")
        };
    }
}