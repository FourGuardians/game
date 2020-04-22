using DialogueTrees.Dialogues;
using System.Linq;

namespace DialogueTrees.Builder.Link
{
    internal static partial class Linker
    {
        private static void LinkText(DialogueTree tree, DialogueText text)
        {
            text.Participant = tree.GetParticipant(text.participantReferenceName);

            if (text.modifierReferenceName != null)
                text.Modifier = tree.GetModifier(text.modifierReferenceName);
        }
    }
}