using DialogueTrees.Dialogues;
using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class ToDialogueAction : Action
    {
        internal ToDialogueAction() {}

        public Dialogue Dialogue { get; internal set; }

        internal string dialogueReferenceName;

        public override IEnumerable<Instruction> Run()
        {
            foreach (Instruction instruction in Dialogue.Run())
                yield return instruction;
        }
    }
}