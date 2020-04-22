using DialogueTrees.Instructions;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class OptionsAction : Action
    {
        internal OptionsAction() {}

        public List<Option> Options { get; internal set; }

        public override IEnumerable<Instruction> Run()
        {
            var instruction = new OptionsInstruction()
            {
                Options = this
            };

            yield return instruction;

            if (instruction.Result == null)
                yield break;

            foreach (Instruction inst in instruction.Result.Action.Run())
                yield return inst;
        }
    }
}