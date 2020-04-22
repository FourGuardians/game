namespace DialogueTrees.Actions
{
    public class Option
    {
        internal Option() {}

        public string Name { get; internal set; }
        public Action Action { get; internal set; }
    }
}