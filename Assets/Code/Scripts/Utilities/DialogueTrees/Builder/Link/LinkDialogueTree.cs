using DialogueTrees.ActionSets;
using DialogueTrees.Dialogues;

namespace DialogueTrees.Builder.Link
{
    internal static partial class Linker
    {
        internal static DialogueTree LinkDialogueTree(DialogueTree tree)
        {
            // ENTRY
            foreach (DialogueText text in tree.Entry.Text)
                LinkText(tree, text);

            LinkAction(tree, tree.Entry.Action);

            // DIALOGUES
            foreach (Dialogue dialogue in tree.Dialogues)
            {
                foreach (DialogueText text in dialogue.Text)
                    LinkText(tree, text);

                LinkAction(tree, dialogue.Action);
            }

            // ACTION SETS
            foreach (ActionSet action in tree.Actions)
                LinkAction(tree, action.Action);

            return tree;
        }
    }
}