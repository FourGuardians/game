namespace DialogueTrees
{
    public class Modifier
    {
        internal Modifier() {}

        public string Name { get; internal set; }

        public static implicit operator string(Modifier m) =>
            m.Name;
    }
}