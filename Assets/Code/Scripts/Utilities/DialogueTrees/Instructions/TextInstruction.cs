using DialogueTrees.Dialogues;

namespace DialogueTrees.Instructions
{
    public class TextInstruction : Instruction
    {
        public DialogueText Text;

        public bool HasModifier => Text.Modifier != null;
    }
}