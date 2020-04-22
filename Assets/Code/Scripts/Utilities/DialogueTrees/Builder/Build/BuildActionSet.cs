using DialogueTrees.ActionSets;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static ActionSet BuildActionSet(XmlElement element) => new ActionSet()
        {
            Name = element.GetAttribute("name"),
            Action = BuildActionSingle(element)
        };
    }
}