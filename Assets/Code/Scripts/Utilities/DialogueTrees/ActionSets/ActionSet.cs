using DialogueTrees.Actions;
using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.ActionSets
{
    public class ActionSet
    {
        internal ActionSet() {}

        public string Name { get; internal set; }
        public Action Action { get; internal set; }

        public IEnumerable<Instruction> Run()
        {
            foreach (Instruction instruction in Action.Run())
                yield return instruction;
        }
    }
}