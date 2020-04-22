using DialogueTrees.Dialogues;
using System.Xml;

namespace DialogueTrees.Builder.Build
{
    internal static partial class Builder
    {
        private static EntryDialogue BuildEntryDialogue(XmlElement element)
        {
            Dialogue dialogue = BuildDialgue(element);

            return new EntryDialogue()
            {
                Action = dialogue.Action,
                Name = dialogue.Name,
                Text = dialogue.Text
            };
        }
    }
}