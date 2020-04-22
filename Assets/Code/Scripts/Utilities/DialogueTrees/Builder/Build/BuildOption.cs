using DialogueTrees.Actions;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Option BuildOption(XmlElement element) => new Option()
        {
            Name = element.GetAttribute("name"),
            Action = BuildActionSingle(element)
        };
    }
}