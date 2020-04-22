using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Dialogues
{
    public class DialogueText
    {
        internal DialogueText() {}

        public string Content { get; internal set; }
        public Modifier Modifier { get; internal set; }
        public Participant Participant { get; internal set; }

        internal string participantReferenceName;
        internal string modifierReferenceName;

        public IEnumerable<Instruction> Run()
        {
            yield return new TextInstruction()
            {
                Text = this
            };
        }
    }
}