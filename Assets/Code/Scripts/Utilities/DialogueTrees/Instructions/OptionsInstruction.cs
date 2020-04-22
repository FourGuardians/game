using DialogueTrees.Actions;

namespace DialogueTrees.Instructions
{
    public class OptionsInstruction : ActionInstruction
    {
        public OptionsAction Options { get; internal set; }
        public Option Result { get; set; }
    }
}