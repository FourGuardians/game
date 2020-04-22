using DialogueTrees.Instructions;
using System;
using System.Collections.Generic;

namespace DialogueTrees.Actions
{
    public class RandomAction : Action
    {
        internal RandomAction() {}

        public List<Action> Actions { get; internal set; }

        public override IEnumerable<Instruction> Run()
        {
            Action action = Actions[new Random().Next(Actions.Count)];

            foreach (Instruction instruction in action.Run())
                yield return instruction;
        }
    }
}