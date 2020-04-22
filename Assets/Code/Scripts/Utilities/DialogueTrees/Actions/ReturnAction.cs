using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class ReturnAction : Action
    {
        internal ReturnAction() {}

        public string Value { get; internal set; }

        public override IEnumerable<Instruction> Run()
        {
            yield return new ReturnInstruction()
            {
                Value = Value
            };
        }
    }
}