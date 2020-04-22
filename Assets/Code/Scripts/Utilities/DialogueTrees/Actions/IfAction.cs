using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class IfAction : Action
    {
        internal IfAction() {}

        public Property Property { get; internal set; }
        public string Value { get; internal set; }
        public Action TrueAction { get; internal set; }
        public Action FalseAction { get; internal set; }

        internal string propertyReferenceName;

        public override IEnumerable<Instruction> Run()
        {
            Action action = Property.Value == Value ?
                TrueAction :
                FalseAction;
                    
            foreach (Instruction instruction in action.Run())
                yield return instruction;
        }
    }
}