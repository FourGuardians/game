using DialogueTrees.ActionSets;
using DialogueTrees.Dialogues;
using DialogueTrees.Instructions;
using System.Collections.Generic;
using System.Linq;

namespace DialogueTrees
{
    public class DialogueTree
    {
        internal DialogueTree() {}

        public string Name { get; internal set; }
        public List<Participant> Participants { get; internal set; }
        public List<Modifier> Modifiers { get; internal set; }
        public List<Property> Properties { get; internal set; }
        public EntryDialogue Entry { get; internal set; }
        public List<Dialogue> Dialogues { get; internal set; }
        public List<ActionSet> Actions { get; internal set; }

        public string this[string k]
        {
            get
            {
                return Properties.FirstOrDefault(p => p.Name == k).Value;
            }

            set
            {
                Property property = Properties.FirstOrDefault(p => p.Name == k);

                if (property == null)
                    throw new System.Exception($"Could not find property \"{k}\"");

                property.Value = value;
            }
        }

        public IEnumerable<Instruction> Start() =>
            Entry.Run();

        public Participant GetParticipant(string name) =>
            Participants.FirstOrDefault(p => p.Name == name);

        public Modifier GetModifier(string name) =>
            Modifiers.FirstOrDefault(m => m.Name == name);

        public Dialogue GetDialogue(string name) =>
            Dialogues.FirstOrDefault(d => d.Name == name);

        public ActionSet GetAction(string name) =>
            Actions.FirstOrDefault(a => a.Name == name);
    }
}