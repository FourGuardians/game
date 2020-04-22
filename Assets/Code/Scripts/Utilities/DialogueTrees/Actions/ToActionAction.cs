using DialogueTrees.ActionSets;
using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class ToActionAction : Action
    {
        internal ToActionAction() {}

        public ActionSet Action { get; internal set; }

        internal string actionReferenceName;

        public override IEnumerable<Instruction> Run()
        {
            foreach (Instruction instruction in Action.Run())
                yield return instruction;
        }
    }
}