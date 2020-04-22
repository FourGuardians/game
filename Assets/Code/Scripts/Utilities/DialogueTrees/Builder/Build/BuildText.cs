using DialogueTrees.Dialogues;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static DialogueText BuildText(XmlElement element) => new DialogueText()
        {
            Content = element.GetAttribute("text"),

            participantReferenceName = (element.SelectSingleNode("ParticipantReference") as XmlElement)
                .GetAttribute("ref:participant"),

            modifierReferenceName = (element.SelectSingleNode("ModifierReference") as XmlElement)?
                .GetAttribute("ref:modifier")
        };
    }
}