using DialogueTrees.Dialogues;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static Dialogue BuildDialgue(XmlElement element) => new Dialogue()
        {
            Name = element.GetAttribute("name"),
            Action = BuildActionSingle(element),

            Text = new List<DialogueText>
            (
                from e in element.SelectNodes("Text").Cast<XmlElement>()
                select BuildText(e)
            )
        };
    }
}