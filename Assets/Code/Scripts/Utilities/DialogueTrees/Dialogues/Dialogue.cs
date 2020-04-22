using DialogueTrees.Actions;
using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Dialogues
{
    public class Dialogue
    {
        internal Dialogue() {}

        public string Name { get; internal set; }
        public List<DialogueText> Text { get; internal set; }
        public Action Action { get; internal set; }

        public IEnumerable<Instruction> Run()
        {
            foreach (DialogueText text in Text)
                foreach (Instruction instruction in text.Run())
                    yield return instruction;

            foreach (Instruction instruction in Action.Run())
                yield return instruction;
        }
    }
}