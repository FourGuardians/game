using System.Collections.Generic;
using DialogueTrees.Instructions;

namespace DialogueTrees.Actions
{
    public abstract class Action
    {   
        internal Action() {}

        public abstract IEnumerable<Instruction> Run();
    }
}