namespace DialogueTrees
{
    public class Participant
    {
        internal Participant() {}

        public string Name { get; internal set; }

        public static implicit operator string(Participant p) =>
            p.Name;
    }
}