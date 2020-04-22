using DialogueTrees.ActionSets;
using DialogueTrees.Dialogues;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        internal static DialogueTree BuildDialogueTree(XmlElement element) => new DialogueTree()
        {
            Name = element.GetAttribute("name"),
            Entry = BuildEntryDialogue(element.SelectSingleNode("EntryDialogue") as XmlElement),

            Participants = new List<Participant>
            (
                from e in element.SelectNodes("Participant").Cast<XmlElement>()
                select BuildParticipant(e)
            ),

            Modifiers = new List<Modifier>
            (
                from e in element.SelectNodes("Modifier").Cast<XmlElement>()
                select BuildModifier(e)
            ),

            Properties = new List<Property>
            (
                from e in element.SelectNodes("Property").Cast<XmlElement>()
                select BuildProperty(e)
            ),

            Dialogues = new List<Dialogue>
            (
                from e in element.SelectNodes("Dialogue").Cast<XmlElement>()
                select BuildDialgue(e)
            ),

            Actions = new List<ActionSet>
            (
                from e in element.SelectNodes("ActionSet").Cast<XmlElement>()
                select BuildActionSet(e)
            )
        };
    }
}