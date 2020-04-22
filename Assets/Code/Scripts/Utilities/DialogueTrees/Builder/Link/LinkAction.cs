using DialogueTrees.Actions;
using System.Linq;

namespace DialogueTrees.Builder.Link
{
    internal static partial class Linker
    {
        private static void LinkAction(DialogueTree tree, Action action)
        {
            if (action is IfAction ifAction)
                ifAction.Property = tree.Properties.FirstOrDefault(
                    p => p.Name == ifAction.propertyReferenceName
                );

            if (action is OptionsAction optionsAction)
                foreach (Option option in optionsAction.Options)
                    LinkAction(tree, option.Action);

            if (action is RandomAction randomAction)
                foreach (Action act in randomAction.Actions)
                    LinkAction(tree, act);

            if (action is ToActionAction toActionAction)
                toActionAction.Action = tree.GetAction(toActionAction.actionReferenceName);

            if (action is ToDialogueAction toDialogueAction)
                toDialogueAction.Dialogue = tree.GetDialogue(toDialogueAction.dialogueReferenceName);

            if (action is ToEntryAction toEntryAction)
                toEntryAction.Entry = tree.Entry;
        }
    }
}