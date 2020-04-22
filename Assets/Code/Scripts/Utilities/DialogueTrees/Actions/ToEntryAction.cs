using DialogueTrees.Dialogues;
using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class ToEntryAction : Action
    {
        internal ToEntryAction() {}

        public EntryDialogue Entry { get; internal set; }

        public override IEnumerable<Instruction> Run()
        {
            foreach (Instruction instruction in Entry.Run())
                yield return instruction;
        }
    }
}