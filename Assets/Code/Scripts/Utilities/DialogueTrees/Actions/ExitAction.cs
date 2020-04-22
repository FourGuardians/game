using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class ExitAction : Action
    {
        internal ExitAction() {}

        public override IEnumerable<Instruction> Run()
        {
            yield break;
        }
    }
}